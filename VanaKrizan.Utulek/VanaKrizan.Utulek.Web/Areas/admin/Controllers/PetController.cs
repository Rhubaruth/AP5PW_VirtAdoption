using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


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
            ViewBag.Sizes = _petService.SizeSelectAll();
            ViewBag.Breeds = _petService.BreedSelectAll();
            return View();
        }

        [HttpPost]      // default atribut = "HttpGet"
        async public Task<IActionResult> Create(Pet pet)
        {
            //_petService.PetCreate(pet);

            //return RedirectToAction(nameof(PetController.Index), "Pet");

            if(ModelState.IsValid)
            {
                _petService.PetCreate(pet);
                return RedirectToAction(nameof(PetController.Index), "Pet");

            }
            else
            {
                return View(pet);
            }

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

            ViewBag.Sizes = _petService.SizeSelectAll();
            ViewBag.Breeds = _petService.BreedSelectAll();

            PetFile PetWithFile = new PetFile()
            {
                PetObj = pet,
            };

            return View(PetWithFile);  // vrací view s návem "Edit" 
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult Edit(PetFile updatedPet)
        {

            if(updatedPet.ImageFile != null) {
                // Combine the target directory with the unique file name
                var fileName = updatedPet.PetObj.Name.Replace(" ", "_") + updatedPet.PetObj.Id.ToString() + ".jpg";
                var filePath = Path.Combine("wwwroot\\img\\pets", fileName);

                // Copy the file to the target directory
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    updatedPet.ImageFile.CopyToAsync(stream);
                }

                updatedPet.PetObj.ImageSrc = "/img/pets/" + fileName;
            }

            bool isEdited = _petService.PetEdit(updatedPet.PetObj);

            if (isEdited)
                return RedirectToAction(nameof(PetController.Index), "Pet");
            return NotFound();
        }
        #endregion

        #region Funcs for Delete
        public IActionResult Delete(int id)
        {
            bool deleted = _petService.PetDelete(id);
            
            if(deleted)
                return RedirectToAction(nameof(UserController.Index), "User", new { area = "User"});
            return NotFound();
        }
        #endregion
    }
}
