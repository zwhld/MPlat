namespace Camc.MES53.MultiTenancy.Payments.Stripe.Dto
{
    public class StripeConfirmPaymentInput
    {
        public long PaymentId { get; set; }

        public string StripeToken { get; set; }
    }
}