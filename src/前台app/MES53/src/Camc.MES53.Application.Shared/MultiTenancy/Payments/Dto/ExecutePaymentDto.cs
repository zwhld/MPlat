﻿using System.Collections.Generic;
using Camc.MES53.Editions;

namespace Camc.MES53.MultiTenancy.Payments.Dto
{
    public class ExecutePaymentDto
    {
        public SubscriptionPaymentGatewayType Gateway { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public int EditionId { get; set; }

        public PaymentPeriodType PaymentPeriodType { get; set; }

        public Dictionary<string, string> AdditionalData { get; set; }

        public ExecutePaymentDto()
        {
            AdditionalData = new Dictionary<string, string>();
        }
    }
}
