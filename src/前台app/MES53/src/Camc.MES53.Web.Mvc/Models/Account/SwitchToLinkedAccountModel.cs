using System.ComponentModel.DataAnnotations;
using Abp;

namespace Camc.MES53.Web.Models.Account
{
    public class SwitchToLinkedAccountModel
    {
        public int? TargetTenantId { get; set; }

        [Range(1, long.MaxValue)]
        public long TargetUserId { get; set; }

        public UserIdentifier ToUserIdentifier()
        {
            return new UserIdentifier(TargetTenantId, TargetUserId);
        }
    }
}