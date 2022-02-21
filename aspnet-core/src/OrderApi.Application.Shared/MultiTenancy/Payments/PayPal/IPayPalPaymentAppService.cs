using System.Threading.Tasks;
using Abp.Application.Services;
using OrderApi.MultiTenancy.Payments.PayPal.Dto;

namespace OrderApi.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
