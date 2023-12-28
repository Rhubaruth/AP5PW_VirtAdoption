using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;

namespace VanaKrizan.Utulek.Application.Abstraction
{
    public interface IPetService
    {
        #region Pet
        IList<Pet> PetSelectAll();
        Pet? PetSelectById(int id);
        void PetCreate(Pet pet);
        bool PetDelete(int id);
        bool PetEdit(Pet pet);
        #endregion

        #region Size and Breed
        public IList<Size> SizeSelectAll();
        public Size? SizeSelectById(int? id);

        public IList<Breed> BreedSelectAll();
        public Breed? BreedSelectById(int? id);
        #endregion

        #region User
        public IList<User> UserSelectAll();
        User? UserSelectById(int id);
        bool UserDelete(int id);
        bool UserEdit(User pet);

        public IList<Pet> UserGetPetsAll(int id);
        public bool UserAdoptPet(int petId, int userId);

        public IList<int> UserGetRolesAll(int id);
        public bool UserAddRole(int userId, Roles role);
        public bool UserRemoveRole(int userId, Roles role);
        #endregion

    }
}
