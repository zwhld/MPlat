using System.Collections.Generic;
using Camc.MES53.Authorization.Permissions.Dto;

namespace Camc.MES53.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}