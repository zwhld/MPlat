using System.Collections.Generic;
using Camc.MES53.Authorization.Permissions.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}