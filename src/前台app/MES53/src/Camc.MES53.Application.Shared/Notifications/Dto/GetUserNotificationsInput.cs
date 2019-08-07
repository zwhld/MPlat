using Abp.Notifications;
using Camc.MES53.Dto;

namespace Camc.MES53.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}