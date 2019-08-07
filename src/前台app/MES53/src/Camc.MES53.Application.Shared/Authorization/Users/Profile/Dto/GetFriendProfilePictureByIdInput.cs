using System;

namespace Camc.MES53.Authorization.Users.Profile.Dto
{
    public class GetFriendProfilePictureByIdInput
    {
        public Guid? ProfilePictureId { get; set; }

        public long UserId { get; set; }

        public int? TenantId { get; set; }
    }
}
