using System.ComponentModel.DataAnnotations;

namespace Camc.MES53.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}