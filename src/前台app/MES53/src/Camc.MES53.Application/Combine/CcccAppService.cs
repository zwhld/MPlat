using Camc.ZTCost.Application.Shared.MaterialsOutCost;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camc.MES53.Combine
{
    public class CcccAppService : MES53AppServiceBase, ICcccAppService
	{
		private IMaterialsOutCostAppService _materialsOutCostAppService;

		public CcccAppService(IMaterialsOutCostAppService materialsOutCostAppService)
		{
			_materialsOutCostAppService = materialsOutCostAppService;
		}

		//public CcccAppService()
		//{
		//	_materialsOutCostAppService = TypeMixer<object>.ExtendWith<IMaterialsOutCostAppService>(); 
		//}

		public void Act()
		{
			_materialsOutCostAppService.Add();
		}
	}
}
