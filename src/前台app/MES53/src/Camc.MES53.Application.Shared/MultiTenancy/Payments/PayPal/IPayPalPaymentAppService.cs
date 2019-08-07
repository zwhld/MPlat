using System.Threading.Tasks;
using Abp.Application.Services;
using Camc.MES53.MultiTenancy.Payments.Dto;
using Camc.MES53.MultiTenancy.Payments.PayPal.Dto;

namespace Camc.MES53.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalPaymentId, string paypalPayerId);

        PayPalConfigurationDto GetConfiguration();

        Task CancelPayment(CancelPaymentDto input);
    }
}
