using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Camc.MES53.Authorization.Permissions.Dto;

namespace Camc.MES53.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
