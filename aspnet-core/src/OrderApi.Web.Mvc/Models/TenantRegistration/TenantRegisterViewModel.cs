using OrderApi.Editions;
using OrderApi.Editions.Dto;
using OrderApi.MultiTenancy.Payments;
using OrderApi.Security;
using OrderApi.MultiTenancy.Payments.Dto;

namespace OrderApi.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
