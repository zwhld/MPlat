using System.Threading.Tasks;
using Camc.MES53.Security.Recaptcha;

namespace Camc.MES53.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
