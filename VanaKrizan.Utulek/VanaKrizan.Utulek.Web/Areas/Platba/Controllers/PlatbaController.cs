using Microsoft.AspNetCore.Mvc;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    [Area("Platba")]
    public class PlatbaController : Controller
    {
        IHomeService _homeService;
        IPetService _petService;

        public PlatbaController(IHomeService homeService, IPetService petService) 
        { 
            _homeService = homeService;
            _petService = petService;
        }

        public IActionResult Platba(int id, double cost)
        {
            return View();
        }
    }
}
