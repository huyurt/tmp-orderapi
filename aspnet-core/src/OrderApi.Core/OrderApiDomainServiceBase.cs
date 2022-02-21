using Abp.Domain.Services;

namespace OrderApi
{
    public abstract class OrderApiDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected OrderApiDomainServiceBase()
        {
            LocalizationSourceName = OrderApiConsts.LocalizationSourceName;
        }
    }
}
