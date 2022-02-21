using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OrderApi.EntityFrameworkCore;

namespace OrderApi.HealthChecks
{
    public class OrderApiDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public OrderApiDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("OrderApiDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("OrderApiDbContext could not connect to database"));
        }
    }
}
