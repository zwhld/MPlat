using Abp.Application.Services;
using Camc.ZTWorkflow.WorkflowManager.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camc.ZTWorkflow.WorkflowManager
{
    public interface IWorkflowAppService: IApplicationService
	{
		/// <summary>
		/// 开始并取得新流程实例ID
		/// </summary>
		/// <param name="WorkflowID"></param>
		string StartWorkflowInstance(string WorkflowID);



		/// <summary>
		/// 获取需要该用户处理的流程
		/// </summary>
		/// <param name="user"></param>
		/// <param name="WorkflowID"></param>
		/// <returns></returns>
		IEnumerable<WorkflowInstanceDto> GetRunableWorkflowInstanceByUser(string user,string WorkflowID);

		/// <summary>
		/// 获取该用户处理过的流程
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		IEnumerable<WorkflowInstanceDto> GetProcessedWorkflowInstanceByUser(string user, string WorkflowID);

		/// <summary>
		/// 获取该用户处理过的流程
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		IEnumerable<WorkflowInstanceDto> GetCompletedWorkflowInstanceByUser(string user, string WorkflowID);

		
	}
}
