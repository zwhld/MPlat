using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Camc.MES53.Common.Dto;
using Camc.MES53.Editions.Dto;

namespace Camc.MES53.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}