using Abp.AspNetCore.Mvc.ViewComponents;

namespace OrderApi.Web.Public.Views
{
    public abstract class OrderApiViewComponent : AbpViewComponent
    {
        protected OrderApiViewComponent()
        {
            LocalizationSourceName = OrderApiConsts.LocalizationSourceName;
        }
    }
}