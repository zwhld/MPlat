using Abp.Application.Services;
using Camc.MES53.Dto;
using Camc.MES53.Logging.Dto;

namespace Camc.MES53.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
