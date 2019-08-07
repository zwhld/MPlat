using Abp.AutoMapper;
using Camc.MES53.Editions;
using Camc.MES53.MultiTenancy.Payments.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}