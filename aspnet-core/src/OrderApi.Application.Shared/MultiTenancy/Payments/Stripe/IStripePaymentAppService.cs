using System.Threading.Tasks;
using Abp.Application.Services;
using OrderApi.MultiTenancy.Payments.Dto;
using OrderApi.MultiTenancy.Payments.Stripe.Dto;

namespace OrderApi.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}