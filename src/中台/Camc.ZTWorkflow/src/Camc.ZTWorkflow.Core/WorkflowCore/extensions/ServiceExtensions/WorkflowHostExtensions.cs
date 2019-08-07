﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services;
using WorkflowCore.Users.Models;
using WorkflowCore.Users.Primitives;

namespace WorkflowCore.Interface
{
    public static class WorkflowHostExtensions
    {
        public static async Task PublishUserAction(this IWorkflowHost host, string actionKey, string user, object value)
        {
            UserAction data = new UserAction()
            {
                User = user,
                OutcomeValue = value
            };

            await host.PublishEvent(UserTask.EventName, actionKey, data);
        }

        public static IEnumerable<OpenUserAction> GetOpenUserActions(this IWorkflowHost host, string workflowId)
        {
            var workflow = host.PersistenceStore.GetWorkflowInstance(workflowId).Result;
            return workflow.GetOpenUserActions();
        }

		public static IEnumerable<WorkflowInstance> GetRunableWorkflowInstanceByUser(this IWorkflowHost host,string user)
		{
			var workflows = host.PersistenceStore.GetWorkflowInstances(WorkflowStatus.Runnable,"HumanWorkflow", new DateTime(1999, 1, 1), new DateTime(2999, 1, 1),0,0).Result;

			var result = new List<WorkflowInstance>();
			foreach (var worflow in workflows)
			{
				try
				{
					if (worflow.GetOpenUserActions().First().AssignedPrincipal == user)
					{
						result.Add(worflow);
					}
				}
				catch (Exception ex)
				{ }
			}

			return result;
		}
	}
}
