using Microsoft.AspNetCore.Mvc;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    public class MazlicciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
