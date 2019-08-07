using System.Collections.Generic;
using Camc.MES53.Authorization.Permissions.Dto;

namespace Camc.MES53.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}