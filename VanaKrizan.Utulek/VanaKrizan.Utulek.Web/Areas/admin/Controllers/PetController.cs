using Microsoft.AspNetCore.Mvc;

namespace VanaKrizan.Utulek.Web.Areas.admin.Controllers
{
    [Area("admin")] // napojení Controller - Area
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
