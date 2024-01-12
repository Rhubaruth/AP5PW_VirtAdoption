using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;
using VanaKrizan.Utulek.Web.Areas.admin.Controllers;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    [Area("Mazlicci")]
    public class MazlicciController : Controller
    {
        IHomeService _homeService;
        IPetService _petService;
        UserManager<Infrastructure.Identity.User> _userManager;

        public MazlicciController(IHomeService homeService, 
            IPetService petService, 
            UserManager<Infrastructure.Identity.User> userManager) 
        { 
            _homeService = homeService;
            _petService = petService;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            CarouselPetViewModel viewModel = new CarouselPetViewModel();

            //var user = _userManager.GetUserAsync(User).Result;

            var allPets = _petService.PetSelectAll();
            viewModel.PetsConj = _petService.PetMakeConjoined(allPets);

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            Pet? pet = _petService.PetSelectById(id);
            if (pet == null)
            {
                return RedirectToAction(nameof(MazlicciController.Index), "Mazlicci");
            }

            ViewBag.Adopted = false;
            var user = _userManager.GetUserAsync(User).Result;
            if (user != null)
            {
                IList<Pet> userPets = _petService.UserGetPetsAll(user.Id);
                if (userPets.Contains(pet))
                    ViewBag.Adopted = true;
            }


            Size? size = _petService.SizeSelectById(pet.SizeId);
            Breed? breed = _petService.BreedSelectById(pet.BreedId);

            PetConjoined petConj = new PetConjoined
            {
                pet = pet,
                size = size,
                breed = breed,
                cost = 100,
            };

            return View(petConj);
        }

        [HttpPost]
        public IActionResult Detail(PetConjoined petConj)
        {
            if(petConj.pet == null)
                return NotFound();

            petConj.pet = _petService.PetSelectById(petConj.pet.Id);
            TempData["PetData"] = JsonConvert.SerializeObject(petConj);
            return RedirectToAction(nameof(PlatbaController.Platba), "Platba", new { area = "Platba" });
        }


        public IActionResult AdoptPet(int petId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return NotFound();
            }

            var result = _petService.UserAdoptPet(petId, user.Id);
         
            if(result)
                return RedirectToAction(nameof(MazlicciController.Index), "Mazlicci");
            return NotFound();
        }

        public IActionResult RemovePet(int petId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return NotFound();
            }

            var result = _petService.UserRemovePet(petId, user.Id);

            if (result)
                return RedirectToAction(nameof(MazlicciController.Index), "Mazlicci");
            return NotFound();
        }

        [HttpPost]
        public IActionResult RemovePet(PetConjoined petConj)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return NotFound();
            }

            var result = _petService.UserRemovePet(petConj.pet.Id, user.Id);

            if (result)
                return RedirectToAction(nameof(MazlicciController.Index), "Mazlicci");
            return NotFound();
        }

    }
}
