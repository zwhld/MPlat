using System.Threading.Tasks;
using Abp.Application.Services;
using Camc.MES53.Sessions.Dto;

namespace Camc.MES53.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
