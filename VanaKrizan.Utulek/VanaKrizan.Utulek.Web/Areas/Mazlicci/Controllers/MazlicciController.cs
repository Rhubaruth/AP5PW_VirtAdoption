using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    [Area("Mazlicci")]
    public class MazlicciController : Controller
    {
        IHomeService _homeService;
        IPetService _petService;
        UserManager<User> _userManager;

        public MazlicciController(IHomeService homeService, 
            IPetService petService, 
            UserManager<User> userManager) 
        { 
            _homeService = homeService;
            _petService = petService;
            _userManager = userManager;
        }

       
        public IActionResult Index()
        {
            CarouselProductViewModel viewModel = _homeService.GetHomeIndexViewModel(_petService);

            var user = _userManager.GetUserAsync(User).Result;
            if (user != null)
            {
                viewModel.Carousels = _petService.UserGetPetsAll(user.Id);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            Pet? pet = _petService.PetSelectById(id);
            if (pet == null)
            {
                return RedirectToAction(nameof(MazlicciController.Index), "Mazlicci");
            }

            Size? size = _petService.SizeSelectById(pet.SizeId);
            Breed? breed = _petService.BreedSelectById(pet.BreedId);

            return View(new PetConjoined(pet, size, breed));
        }
    }
}
