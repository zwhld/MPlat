using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Camc.MES53.Authorization.Roles.Dto
{
    public class CreateOrUpdateRoleInput
    {
        [Required]
        public RoleEditDto Role { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}