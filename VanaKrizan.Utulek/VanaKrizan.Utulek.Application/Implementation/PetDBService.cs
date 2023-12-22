using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;



namespace VanaKrizan.Utulek.Application.Implementation
{
    public class PetDBService : IPetService
    {
        UtulekDbContext _utulekDbContext;

        public PetDBService(UtulekDbContext dbContext)
        {
            _utulekDbContext = dbContext;
        }


        public void Create(Pet pet)
        {
            _utulekDbContext.Pets.Add(pet);
            _utulekDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            try
            {
                Pet? pet = SelectById(id);
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

        public bool Edit(Pet pet)
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

        public IList<Pet> Select()
        {
            return _utulekDbContext.Pets.ToList();
        }

        public Pet? SelectById(int id)
        {
            return _utulekDbContext.Pets.Where(pet  => pet.Id == id).FirstOrDefault();
        }
    }
}
