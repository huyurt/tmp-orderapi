using System.Collections.Generic;
using OrderApi.Editions.Dto;
using OrderApi.MultiTenancy.Payments;

namespace OrderApi.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}