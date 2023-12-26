using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;

namespace VanaKrizan.Utulek.Web.Areas.admin.Controllers
{
    [Area("admin")] // napojení Controller - Area
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class PetController : Controller
    {
        IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult Index()
        {
            IList<Pet> pets = _petService.PetSelectAll();
            return View(pets);
        }


        #region Funcs for Create 
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult Create(Pet pet)
        {
            _petService.PetCreate(pet);

            return RedirectToAction(nameof(PetController.Index), "Pet");
        }
        #endregion

        #region Funcs for Edit
        public IActionResult Edit(int id)
        {
            Pet? pet = _petService.PetSelectById(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);  // vrací view s návem "Edit" 
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult Edit(Pet updatedPet)
        {

            bool isEdited = _petService.PetEdit(updatedPet);

            if (isEdited)
                return RedirectToAction(nameof(PetController.Index));
            return NotFound();
        }
        #endregion

        #region Funcs for Delete
        public IActionResult Delete(int id)
        {
            bool deleted = _petService.PetDelete(id);
            
            if(deleted)
                return RedirectToAction(nameof(PetController.Index));
            return NotFound();
        }
        #endregion
    }
}
