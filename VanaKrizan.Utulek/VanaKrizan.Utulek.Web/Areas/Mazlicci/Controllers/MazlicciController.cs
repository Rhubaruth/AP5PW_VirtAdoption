using Microsoft.AspNetCore.Mvc;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    public class MazlicciController : Controller
    {
        IHomeService _homeService;
        IPetService _petService;

        public MazlicciController(IHomeService homeService, IPetService petService) 
        { 
            _homeService = homeService;
            _petService = petService;
        }

        [Area("Mazlicci")]
        public IActionResult Index()
        {
            CarouselProductViewModel viewModel = _homeService.GetHomeIndexViewModel(_petService);
            return View(viewModel);
        }
    }
}
