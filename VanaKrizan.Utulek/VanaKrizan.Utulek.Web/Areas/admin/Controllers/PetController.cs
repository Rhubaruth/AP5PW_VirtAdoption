using Microsoft.AspNetCore.Mvc;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;
using VanaKrizan.Utulek.Application.Abstraction;

namespace VanaKrizan.Utulek.Web.Areas.admin.Controllers
{
    [Area("admin")] // napojení Controller - Area
    public class PetController : Controller
    {
        IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult Index()
        {
            IList<Pet> pets = _petService.Select();
            return View(pets);
        }

        public IActionResult Create()
        {
            return View();  // vrací view s návem "Create" 
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult Create(Pet pet)
        {
            _petService.Create(pet);

            return RedirectToAction(nameof(PetController.Index));
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _petService.Delete(id);
            
            if(deleted)
                return RedirectToAction(nameof(PetController.Index));
            return NotFound();
        }
    }
}
