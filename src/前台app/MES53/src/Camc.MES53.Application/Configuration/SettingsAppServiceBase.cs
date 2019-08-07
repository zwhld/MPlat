using System.Threading.Tasks;
using Abp.Net.Mail;
using Camc.MES53.Configuration.Host.Dto;

namespace Camc.MES53.Configuration
{
    public abstract class SettingsAppServiceBase : MES53AppServiceBase
    {
        private readonly IEmailSender _emailSender;

        protected SettingsAppServiceBase(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        #region Send Test Email

        public async Task SendTestEmail(SendTestEmailInput input)
        {
            await _emailSender.SendAsync(
                input.EmailAddress,
                L("TestEmail_Subject"),
                L("TestEmail_Body")
            );
        }

        #endregion
    }
}
