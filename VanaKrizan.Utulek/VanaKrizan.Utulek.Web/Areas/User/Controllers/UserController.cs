using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.Implementation;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;
using VanaKrizan.Utulek.Web.Models;

namespace VanaKrizan.Utulek.Web.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        IHomeService _homeService;
        private IPetService _petService;
        UserManager<User> _userManager;

        public UserController(IHomeService homeService, IPetService petService, UserManager<User> userManager)
        {
            _homeService = homeService;
            _petService = petService;
            _userManager = userManager;
        }

        public IActionResult MyPets()
        {
            var thisUser = _userManager.GetUserAsync(User).Result;

            CarouselProductViewModel viewModel = new CarouselProductViewModel();
            viewModel.Carousels = new List<Pet>();
            if (thisUser != null)
            {
                viewModel.Carousels = _petService.UserGetPetsAll(thisUser.Id);
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