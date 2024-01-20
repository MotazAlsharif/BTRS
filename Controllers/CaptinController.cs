using Microsoft.AspNetCore.Mvc;

namespace BRTS.Web.Controllers
{
    public class CaptinController : Controller
    {
        public IActionResult captinDashBoard()
        {
            return View();
        }
    }
}
