using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Web.Areas.App.Models.Layout;
using OrderApi.Web.Views;

namespace OrderApi.Web.Areas.App.Views.Shared.Components.
    AppQuickThemeSelect
{
    public class AppQuickThemeSelectViewComponent : OrderApiViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            return Task.FromResult<IViewComponentResult>(View(new QuickThemeSelectionViewModel
            {
                CssClass = cssClass
            }));
        }
    }
}
