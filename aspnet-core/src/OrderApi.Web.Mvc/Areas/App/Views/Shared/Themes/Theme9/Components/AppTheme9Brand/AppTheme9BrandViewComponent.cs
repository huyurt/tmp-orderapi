﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Web.Areas.App.Models.Layout;
using OrderApi.Web.Session;
using OrderApi.Web.Views;

namespace OrderApi.Web.Areas.App.Views.Shared.Themes.Theme9.Components.AppTheme9Brand
{
    public class AppTheme9BrandViewComponent : OrderApiViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme9BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
