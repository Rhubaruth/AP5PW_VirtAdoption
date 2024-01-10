using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;

namespace VanaKrizan.Utulek.Web.Areas.Mazlicci.Controllers
{
    [Area("Platba")]
    public class PlatbaController : Controller
    {
        UserManager<User> _userManager;
        IPetService _petService;

        public PlatbaController(UserManager<User> userManager, IPetService petService) 
        {
            _userManager = userManager;
            _petService = petService;
        }

        public IActionResult Platba()
        {
            return View();
            PetConjoined? petConj = JsonConvert.DeserializeObject<PetConjoined>((string)TempData["PetData"]);
            if (petConj == null)
                return NotFound();
            return View(petConj);
        }

        [HttpPost]
        public IActionResult Platba(PetConjoined? petConj)
        {
            if (petConj == null || petConj.pet == null)
                return NotFound();

            var thisUser = _userManager.GetUserAsync(User).Result;
            if (thisUser == null)
                return NotFound();

            if (!_petService.UserAdoptPet(petConj.pet.Id, thisUser.Id))
                return BadRequest();

            return RedirectToAction(nameof(MazlicciController.Index), "Mazlicci", new {area = "Mazlicci"});
        }
    }
}
