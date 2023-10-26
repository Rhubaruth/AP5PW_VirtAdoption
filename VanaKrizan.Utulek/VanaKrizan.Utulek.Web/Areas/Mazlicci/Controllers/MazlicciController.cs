using Microsoft.AspNetCore.Mvc;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    public class MazlicciController : Controller
    {
        IHomeService _homeService;

        public MazlicciController(IHomeService homeService) 
        { 
            _homeService = homeService;

        }

        [Area("Mazlicci")]
        public IActionResult Index()
        {
            CarouselProductViewModel viewModel = _homeService.GetHomeIndexViewModel();
            return View(viewModel);
        }
    }
}
