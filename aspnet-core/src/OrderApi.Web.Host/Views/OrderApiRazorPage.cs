using Abp.AspNetCore.Mvc.Views;

namespace OrderApi.Web.Views
{
    public abstract class OrderApiRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected OrderApiRazorPage()
        {
            LocalizationSourceName = OrderApiConsts.LocalizationSourceName;
        }
    }
}
