using Microsoft.AspNetCore.Mvc;
using OrderApi.Web.Controllers;

namespace OrderApi.Web.Public.Controllers
{
    public class AboutController : OrderApiControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}