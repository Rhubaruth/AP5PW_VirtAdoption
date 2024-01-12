using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Web.Models;
using VanaKrizan.Utulek.Infrastructure.Identity;

namespace VanaKrizan.Utulek.Web.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        IHomeService _homeService;
        private IPetService _petService;
        UserManager<Infrastructure.Identity.User> _userManager;

        public UserController(IHomeService homeService, IPetService petService, UserManager<Infrastructure.Identity.User> userManager)
        {
            _homeService = homeService;
            _petService = petService;
            _userManager = userManager;
        }

        public IActionResult MyPets()
        {
            var thisUser = _userManager.GetUserAsync(User).Result;

            CarouselPetViewModel viewModel = new CarouselPetViewModel();
            viewModel.PetsConj = new List<PetConjoined>();
            if (thisUser != null)
            {
                var pets = _petService.UserGetPetsAll(thisUser.Id);
                viewModel.PetsConj = _petService.PetMakeConjoined(pets);
            }

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