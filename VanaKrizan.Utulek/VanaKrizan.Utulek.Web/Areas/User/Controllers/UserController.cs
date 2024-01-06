using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.Implementation;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Web.Models;

namespace VanaKrizan.Utulek.Web.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        IHomeService _homeService;
        private IPetService _petService;

        public UserController(IHomeService homeService, IPetService petService)
        {
            _homeService = homeService;
            _petService = petService;
        }

        public IActionResult MyPets()
        {
            CarouselProductViewModel viewModel = _homeService.GetHomeIndexViewModel(_petService);

            return View(viewModel);
        }

        public IActionResult MyData()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}