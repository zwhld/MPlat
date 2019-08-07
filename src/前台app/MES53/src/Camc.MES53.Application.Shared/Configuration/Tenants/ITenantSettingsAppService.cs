using System.Threading.Tasks;
using Abp.Application.Services;
using Camc.MES53.Configuration.Tenants.Dto;

namespace Camc.MES53.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
