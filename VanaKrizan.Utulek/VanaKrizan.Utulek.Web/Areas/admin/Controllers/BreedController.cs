using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;
using Microsoft.EntityFrameworkCore;

namespace VanaKrizan.Utulek.Web.Areas.admin.Controllers
{
    [Area("admin")] // napojení Controller - Area
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class BreedController : Controller
    {
        IPetService _petService;
        public BreedController(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult Index()
        {
            IList<Breed> breeds = _petService.BreedSelectAll();
            return View(breeds);
        }


        #region Funcs for Create 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult Create(Breed breed)
        {
            _petService.BreedCreate(breed);

            return RedirectToAction(nameof(BreedController.Index), "Breed");
        }
        #endregion

        #region Funcs for Edit
        public IActionResult Edit(int id)
        {
            Breed? item = _petService.BreedSelectById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);  // vrací view s návem "Edit" 
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult Edit(Breed updatedItem)
        {
            bool isEdited = _petService.BreedEdit(updatedItem);

            if (isEdited)
                return RedirectToAction(nameof(BreedController.Index));
            return NotFound();
        }
        #endregion

        #region Funcs for Delete
        public IActionResult Delete(int id)
        {
            bool deleted = _petService.BreedDelete(id);
            
            if(deleted)
                return RedirectToAction(nameof(PetController.Index));
            return NotFound();
        }
        #endregion
    }
}
