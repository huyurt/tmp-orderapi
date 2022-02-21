using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Web.Areas.App.Models.Layout;
using OrderApi.Web.Session;
using OrderApi.Web.Views;

namespace OrderApi.Web.Areas.App.Views.Shared.Components.AppLogo
{
    public class AppLogoViewComponent : OrderApiViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppLogoViewComponent(
            IPerRequestSessionCache sessionCache
        )
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null, string logoClass = "")
        {
            var headerModel = new LogoViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                LogoSkinOverride = logoSkin,
                LogoClassOverride = logoClass
            };

            return View(headerModel);
        }
    }
}
