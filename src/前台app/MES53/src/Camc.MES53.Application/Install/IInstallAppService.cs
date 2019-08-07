using System.Threading.Tasks;
using Abp.Application.Services;
using Camc.MES53.Install.Dto;

namespace Camc.MES53.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}