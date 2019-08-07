using System.Threading.Tasks;
using Abp.Application.Services;
using Camc.MES53.Configuration.Host.Dto;

namespace Camc.MES53.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
