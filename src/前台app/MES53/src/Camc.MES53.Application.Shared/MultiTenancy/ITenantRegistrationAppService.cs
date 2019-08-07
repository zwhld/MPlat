using System.Threading.Tasks;
using Abp.Application.Services;
using Camc.MES53.Editions.Dto;
using Camc.MES53.MultiTenancy.Dto;

namespace Camc.MES53.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}