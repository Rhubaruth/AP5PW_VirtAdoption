using Microsoft.AspNetCore.Mvc;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Web.Areas.admin.Controllers
{
    [Area("admin")] // napojení Controller - Area
    public class CreatorController : Controller
    {

        IPetService _petService;
        public CreatorController(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region Dog Creation
        public IActionResult CreateDog()
        {

            return View();
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult CreateDog(Dog pet)
        {
            _petService.Create(pet);

            return RedirectToAction(nameof(CreatorController.Index), "Pet");
        }
        #endregion

        #region Cat Creation 
        public IActionResult CreateCat()
        {

            return View();
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult CreateCat(Cat pet)
        {
            _petService.Create(pet);

            return RedirectToAction(nameof(CreatorController.Index), "Pet");
        }
        #endregion


    }
}
