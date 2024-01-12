using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;
using Microsoft.EntityFrameworkCore;
using VanaKrizan.Utulek.Domain.Entities.Interface;
using Microsoft.AspNetCore.Identity;
using VanaKrizan.Utulek.Infrastructure.Identity;
using VanaKrizan.Utulek.Infrastructure.HelperClasses;


namespace VanaKrizan.Utulek.Web.Areas.admin.Controllers
{
    [Area("admin")] // napojení Controller - Area
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class UserController : Controller
    {
        IPetService _petService;
        UserManager<Infrastructure.Identity.User> _userManager;

        public UserController(IPetService petService, UserManager<Infrastructure.Identity.User> userManager)
        {
            _petService = petService;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            IList<Infrastructure.Identity.User> users = _petService.UserSelectAll();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var thisUser = _userManager.GetUserAsync(User).Result;
            if (thisUser == null)
                return NotFound();
            if (thisUser.Id == id)
                return BadRequest();

            var adoptedPets = _petService.UserGetPetsAll(id);

            foreach( var pet in adoptedPets )
            {
                _petService.UserRemovePet(pet.Id, id);
            }



            _petService.UserDelete(id);
            return RedirectToAction(nameof(UserController.Index));
        }


        #region Funcs for Edit
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            Infrastructure.Identity.User? user = _petService.UserSelectById(id);
            if (user == null)
                return NotFound();

            IList<int> usersRoles = _petService.UserGetRolesAll(id);
            
            UserConjoined userCon = new UserConjoined();
            userCon.User = user;
            userCon.IsAdmin = usersRoles.Contains((int)Roles.Admin);
            userCon.IsManager = usersRoles.Contains((int)Roles.Manager);
            userCon.IsCustomer = usersRoles.Contains((int)Roles.Customer);

            return View(userCon);  
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult EditUser(UserConjoined updatedUser)
        {


            int id = updatedUser.User.Id;
            List<bool> roleUpdates = new List<bool>();
            IList<int> usersRoles = _petService.UserGetRolesAll(id);
            if (updatedUser.IsAdmin && !usersRoles.Contains((int)Roles.Admin))
                roleUpdates.Add(_petService.UserAddRole(id, Roles.Admin));
            else if(!updatedUser.IsAdmin && usersRoles.Contains((int)Roles.Admin))
                roleUpdates.Add(_petService.UserRemoveRole(id, Roles.Admin));

            if (updatedUser.IsManager && !usersRoles.Contains((int)Roles.Manager))
                roleUpdates.Add(_petService.UserAddRole(id, Roles.Manager));
            else if (!updatedUser.IsManager && usersRoles.Contains((int)Roles.Manager))
                roleUpdates.Add(_petService.UserRemoveRole(id, Roles.Manager));

            if (updatedUser.IsCustomer && !usersRoles.Contains((int)Roles.Customer))
                roleUpdates.Add(_petService.UserAddRole(id, Roles.Customer));
            //else if (!updatedUser.IsCustomer && usersRoles.Contains((int)Roles.Customer))
                //roleUpdates.Add(_petService.UserRemoveRole(id, Roles.Customer));

            
            if(roleUpdates.Contains(false))
                return NotFound();

            bool isEdited = _petService.UserEdit(updatedUser.User);

            if (isEdited)
                return RedirectToAction(nameof(UserController.Index));
            return NotFound();
        }
        #endregion


        #region Funcs for User-Pet edit
        [HttpGet]
        public IActionResult UsersPets(int id)
        {
            Infrastructure.Identity.User? user = _petService.UserSelectById(id);
            if (user == null)
                return NotFound();

            IList<Pet> userPets = _petService.UserGetPetsAll(id);
            IList<Pet> otherPets = _petService.PetSelectAll();
            
            foreach(Pet pet in userPets)
            {
                otherPets.Remove(pet);
            }

            // nonePet to prepand both lists with
            // used when admid doesnt want to add/remove
            Pet nonePet = new Pet();
            nonePet.Id = 0;
            nonePet.Name = "---";
    

            UserPets data = new UserPets()
            {
                UserId = user.Id,
                adoptedPets = userPets.Prepend(nonePet).ToList(),
                otherPets = otherPets.Prepend(nonePet).ToList(),
                addPetId = 0,
                removePetId = 0,
            };
            ViewBag.Username = user.UserName;

            return View(data);
        }

        [HttpPost]      // default atribut = "HttpGet"
        public IActionResult UsersPets(UserPets updatedData)
        {
            if (updatedData.addPetId != 0)
            {
                _petService.UserAdoptPet(updatedData.addPetId, updatedData.UserId);
            }   
            if(updatedData.removePetId != 0)
            {
                _petService.UserRemovePet(updatedData.removePetId, updatedData.UserId);
            }

            return RedirectToAction(nameof(UserController.Index));
        }
        #endregion

    }

    public class RoleCheck
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
