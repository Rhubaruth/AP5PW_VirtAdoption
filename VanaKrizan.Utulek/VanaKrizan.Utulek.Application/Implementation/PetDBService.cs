using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Domain.Entities.Interface;
using VanaKrizan.Utulek.Infrastructure.Database;
using VanaKrizan.Utulek.Infrastructure.Database.Classes;
using VanaKrizan.Utulek.Infrastructure.Identity;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;

namespace VanaKrizan.Utulek.Application.Implementation
{
    public class PetDBService : IPetService
    {
        UtulekDbContext _utulekDbContext;

        public PetDBService(UtulekDbContext dbContext)
        {
            _utulekDbContext = dbContext;
        }

        #region Tabulka Pets
        public void PetCreate(Pet pet)
        {
            _utulekDbContext.Pets.Add(pet);
            _utulekDbContext.SaveChanges();
        }

        public bool PetDelete(int id)
        {
            Pet? pet = PetSelectById(id);
            if (pet == null)
                return false;

            try
            {
                _utulekDbContext.Pets.Remove(pet);
                _utulekDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PetEdit(Pet pet)
        {
            try
            {
                _utulekDbContext.Update(pet);
                _utulekDbContext.SaveChanges();
                return true;
            } 
            catch (Exception)
            {
                return false;
            }
        }

        public IList<Pet> PetSelectAll()
        {
            return _utulekDbContext.Pets.ToList();
        }

        public IList<Pet> PetSelectAllOrderedDate()
        {
            IList<Pet> list = _utulekDbContext.Pets.OrderBy(x => x.InShelterSince).ToList();
            return list.Reverse().ToList();
        }

        public Pet? PetSelectById(int id)
        {
            return _utulekDbContext.Pets.Where(pet  => pet.Id == id).FirstOrDefault();
        }
        #endregion

        #region Tabulka Sizes
        public IList<Size> SizeSelectAll()
        {
            return _utulekDbContext.Sizes.ToList();
        }

        public Size? SizeSelectById(int? id)
        {
            if (id == null) return new Size { Id = -1, Name = "Nedefinováno"};
            return _utulekDbContext.Sizes.Where(size => size.Id == id).FirstOrDefault();
        }
        #endregion

        #region Tabulka Breeds
        public IList<Breed> BreedSelectAll()
        {
            return _utulekDbContext.Breeds.ToList();
        }

        public Breed? BreedSelectById(int? id)
        {
            if (id == null) return new Breed { Id = -1, Name = "Nedefinováno"};
            return _utulekDbContext.Breeds.Where(size => size.Id == id).FirstOrDefault();
        }

        public void BreedCreate(Breed breed)
        {
            _utulekDbContext.Breeds.Add(breed);
            _utulekDbContext.SaveChanges();
        }

        public bool BreedEdit(Breed breed)
        {
            try
            {
                _utulekDbContext.Update(breed);
                _utulekDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BreedDelete(int id)
        {
            Breed? breed = BreedSelectById(id);
            if (breed == null)
                return false;

            try
            {
                _utulekDbContext.Breeds.Remove(breed);
                _utulekDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Users
        public IList<User> UserSelectAll()
        {
            return _utulekDbContext.Users.ToList();
        }

        public IList<Pet> UserGetPetsAll(int userId)
        {
            IList<int> petIds = _utulekDbContext.UserHasPet.
                Where(user => user.UserId == userId).
                Select(pet => pet.PetId).ToList();
            IList<Pet> pets = _utulekDbContext.Pets.Where(pet => petIds.Contains(pet.Id)).ToList();

            return pets;
        }

        public bool UserAdoptPet(int petId, int userId)
        {
            bool isnotPetInDb = _utulekDbContext.Pets.Where(p => p.Id == petId).FirstOrDefault() == null;
            bool isUserHavePet = _utulekDbContext.UserHasPet.Where(line => line.UserId == userId && line.PetId == petId).FirstOrDefault() != null;

            if ( isnotPetInDb || isUserHavePet)
                return false;


            UserHasPet line = new UserHasPet {
                UserId = userId,
                PetId = petId,
            };
            _utulekDbContext.UserHasPet.Add(line);
            _utulekDbContext.SaveChanges();
           

            return true;
        }

        public User? UserSelectById(int id)
        {
            return _utulekDbContext.Users.Where(u  => u.Id == id).FirstOrDefault();
        }

        public bool UserDelete(int id)
        {
            User? user = UserSelectById(id);
            if(user == null)
                return false;

            try
            {
                _utulekDbContext.Users.Remove(user);
                _utulekDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UserEdit(User user)
        {
            try
            {
                if(user.Email != null)
                    user.NormalizedEmail = user.Email.ToUpper();
                if(user.UserName != null)
                    user.NormalizedUserName = user.UserName.ToUpper();

                _utulekDbContext.Users.Update(user);
                _utulekDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<int> UserGetRolesAll(int id)
        {
            IList<int> roleIds = _utulekDbContext.UserRoles.
                Where(user => user.UserId == id).
                Select(role => role.RoleId).ToList();

            return roleIds;
        }

        public bool UserAddRole(int userId, Roles role)
        {
            try
            {

                _utulekDbContext.UserRoles.Add(new IdentityUserRole<int>()
                {
                    UserId = userId,
                    RoleId = (int)role
                });
                return true;
            }
            catch { return false; }
        }

        public bool UserRemoveRole(int userId, Roles role)
        {
            try
            {

                _utulekDbContext.UserRoles.Remove(new IdentityUserRole<int>()
                {
                    UserId = userId,
                    RoleId = (int)role
                });
                return true;
            }
            catch { return false; }

        }

        #endregion
    }
}
