using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Authorization;
using OrderApi.DashboardCustomization;
using System.Threading.Tasks;
using OrderApi.Web.Areas.App.Startup;

namespace OrderApi.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class TenantDashboardController : CustomizableDashboardControllerBase
    {
        public TenantDashboardController(DashboardViewConfiguration dashboardViewConfiguration, 
            IDashboardCustomizationAppService dashboardCustomizationAppService) 
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(OrderApiDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard);
        }
    }
}