using System.Collections.Generic;
using Camc.MES53.Editions.Dto;
using Camc.MES53.MultiTenancy.Payments;

namespace Camc.MES53.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}