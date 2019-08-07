using Abp.Application.Services;
using Camc.ZTWorkflow.WorkflowManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;


namespace Camc.ZTWorkflow.WorkflowManager
{
	public class WorkflowAppService : ApplicationService,IWorkflowAppService
	{
		private readonly IWorkflowHost _workflowHost;

		public WorkflowAppService(IWorkflowHost workflowHost)
		{
			_workflowHost = workflowHost;
		}

		public IEnumerable<WorkflowInstanceDto> GetCompletedWorkflowInstanceByUser(string user, string WorkflowID)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<WorkflowInstanceDto> GetProcessedWorkflowInstanceByUser(string user, string WorkflowID)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<WorkflowInstanceDto> GetRunableWorkflowInstanceByUser(string user, string WorkflowID)
		{
			throw new NotImplementedException();
		}

		public string StartWorkflowInstance(string WorkflowID)
		{
			return _workflowHost.StartWorkflow(WorkflowID).Result;
		}
	}
}
