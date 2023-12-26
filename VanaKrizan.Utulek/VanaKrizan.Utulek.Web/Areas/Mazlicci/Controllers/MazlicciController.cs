﻿using Microsoft.AspNetCore.Mvc;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    [Area("Mazlicci")]
    public class MazlicciController : Controller
    {
        IHomeService _homeService;
        IPetService _petService;

        public MazlicciController(IHomeService homeService, IPetService petService) 
        { 
            _homeService = homeService;
            _petService = petService;
        }

       
        public IActionResult Index()
        {
            CarouselProductViewModel viewModel = _homeService.GetHomeIndexViewModel(_petService);
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
