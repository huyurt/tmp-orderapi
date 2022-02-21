using System.Collections.Generic;
using OrderApi.Editions;
using OrderApi.Editions.Dto;
using OrderApi.MultiTenancy.Payments;
using OrderApi.MultiTenancy.Payments.Dto;

namespace OrderApi.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
