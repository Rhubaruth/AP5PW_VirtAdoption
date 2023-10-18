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

        /* Funcs for Create */

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

        /* Funcs for Edit */

        public IActionResult Edit()
        {
            return View();  // vrací view s návem "Create" 
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult Edit(int id)
        {
            Pet? pet = _petService.SelectById(id);
            if (pet == null)
            {
                return NotFound();
            }

            bool isEdited = _petService.Edit(pet);

            if (isEdited)
                return RedirectToAction(nameof(PetController.Index));
            return NotFound();
        }

        /* Funcs for Delete */

        public IActionResult Delete(int id)
        {
            bool deleted = _petService.Delete(id);
            
            if(deleted)
                return RedirectToAction(nameof(PetController.Index));
            return NotFound();
        }
    }
}
