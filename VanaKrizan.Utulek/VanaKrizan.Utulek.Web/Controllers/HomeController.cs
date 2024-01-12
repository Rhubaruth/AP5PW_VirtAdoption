using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Web.Models;

namespace VanaKrizan.Utulek.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IPetService _petService;

        public HomeController(ILogger<HomeController> logger, IPetService petService)
        {
            _logger = logger;
            _petService = petService;
        }

        public IActionResult Index()
        {
            CarouselPetViewModel viewModel = new CarouselPetViewModel();
            List<Pet> pets = _petService.PetSelectAllOrderedDate().Take(3).ToList();
            viewModel.PetsConj = _petService.PetMakeConjoined(pets);

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aktuality()
        {
            return View();
        }

        public IActionResult Info()
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