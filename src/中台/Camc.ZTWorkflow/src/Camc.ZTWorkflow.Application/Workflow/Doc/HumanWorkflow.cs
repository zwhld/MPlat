using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Camc.ZTWorkflow.Workflow.Doc
{
	public class HumanWorkflow : IWorkflow
	{
		public string Id => "HumanWorkflow";

		public int Version => 1;

		public void Build(IWorkflowBuilder<object> builder)
		{
			builder
				.StartWith(context => ExecutionResult.Next())
				.UserTask("Do you approve", data => @"domain\bob", "111")
					.WithOption("yes", "I approve").Do(then => then
						.StartWith(context => Console.WriteLine("You approved"))
					)
					.WithOption("no", "I do not approve").Do(then => then
						.StartWith(context => Console.WriteLine("You did not approve"))
					)

				  .UserTask("Do you approve1", data => @"domain\aaaa", "222")
					.WithOption("yes", "I approve").Do(then => then
						.StartWith(context => Console.WriteLine("You approved"))
					)
					.WithOption("no", "I do not approve").Do(then => then
						.StartWith(context => Console.WriteLine("You did not approve"))
					)
					.Id("step2")
				.Then(context => Console.WriteLine("end"));
		}
	}
}
