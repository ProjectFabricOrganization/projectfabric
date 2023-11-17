using Microsoft.AspNetCore.Mvc;

namespace ProjectFabric.Api.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
