using Microsoft.AspNetCore.Mvc;
using OrderApi.Web.Controllers;

namespace OrderApi.Web.Public.Controllers
{
    public class HomeController : OrderApiControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}