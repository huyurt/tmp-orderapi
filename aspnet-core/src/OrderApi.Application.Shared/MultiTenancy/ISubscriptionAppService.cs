using System.Threading.Tasks;
using Abp.Application.Services;

namespace OrderApi.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
