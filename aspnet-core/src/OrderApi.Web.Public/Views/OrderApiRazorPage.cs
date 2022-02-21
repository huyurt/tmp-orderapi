using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace OrderApi.Web.Public.Views
{
    public abstract class OrderApiRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected OrderApiRazorPage()
        {
            LocalizationSourceName = OrderApiConsts.LocalizationSourceName;
        }
    }
}
