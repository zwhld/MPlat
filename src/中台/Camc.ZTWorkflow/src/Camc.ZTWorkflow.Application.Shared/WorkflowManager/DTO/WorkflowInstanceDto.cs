using System;
using System.Collections.Generic;
using System.Text;

namespace Camc.ZTWorkflow.WorkflowManager.DTO
{
    public class WorkflowInstanceDto
    {
		public string Id { get; set; }

		public string WorkflowDefinitionId { get; set; }

		public int Version { get; set; }

		public string Description { get; set; }

		public string Reference { get; set; }

		public long? NextExecution { get; set; }

		public WorkflowDtoStatus Status { get; set; }

		public DateTime CreateTime { get; set; }

		public DateTime? CompleteTime { get; set; }

	}

	public enum WorkflowDtoStatus
	{
		Runnable = 0,
		Suspended = 1,
		Complete = 2,
		Terminated = 3
	}
}
