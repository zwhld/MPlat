using System.Threading.Tasks;

namespace Camc.MES53.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}