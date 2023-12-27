using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;
using VanaKrizan.Utulek.Infrastructure.Database.Classes;

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
            try
            {
                Pet? pet = PetSelectById(id);
                if (pet == null)
                {
                    return false;
                }

                _utulekDbContext.Remove(pet);
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
        #endregion

        public IList<Pet> UserGetPetsAll(int userId)
        {
            IList<int> petIds = _utulekDbContext.UserHasPet.
                Where(user => user.UserId == userId).
                Select(pet => pet.PetId).ToList();
            IList<Pet> pets = _utulekDbContext.Pets.Where(pet => petIds.Contains(pet.Id)).ToList();

            return pets;
        }
    }
}
