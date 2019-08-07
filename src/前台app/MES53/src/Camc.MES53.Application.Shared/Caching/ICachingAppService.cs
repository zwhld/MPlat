using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Camc.MES53.Caching.Dto;

namespace Camc.MES53.Caching
{
    public interface ICachingAppService : IApplicationService
    {
        ListResultDto<CacheDto> GetAllCaches();

        Task ClearCache(EntityDto<string> input);

        Task ClearAllCaches();
    }
}
