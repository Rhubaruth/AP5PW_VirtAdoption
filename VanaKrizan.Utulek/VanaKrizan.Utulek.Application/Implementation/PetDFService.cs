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
    public class PetDFService : IPetService
    {
        IList<Pet> IPetService.Select()
        {
            return DatabaseFake.Pets;
        }

        Pet? IPetService.SelectById(int id)
        {
            foreach(Pet pet in DatabaseFake.Pets)
            {
                if(pet.Id == id) return pet;
            }
            return null;
        }

        public void Create(Pet pet)
        {
            // fake id
            if (DatabaseFake.Pets != null && DatabaseFake.Pets.Count > 0) {
                pet.Id = DatabaseFake.Pets.Last().Id + 1;
            }
            else
            {
                pet.Id = 1;
            }

            // add to DatabaseFake
            if (DatabaseFake.Pets == null)
                return;
            DatabaseFake.Pets.Add(pet);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Pet? pet = DatabaseFake.Pets.FirstOrDefault(prod => prod.Id == id);
            if (pet != null)
            {
                deleted = DatabaseFake.Pets.Remove(pet);
            }


            return deleted;
        }

        public bool Edit(Pet pet)
        {
            bool _isEdited = false;

            Pet? existingPet = DatabaseFake.Pets.FirstOrDefault(p => p.Id == pet.Id);
            if (existingPet == null)
                return false;

            existingPet.Name = pet.Name;
            existingPet.Birth = pet.Birth;
            existingPet.Sex = pet.Sex;
            existingPet.Info = pet.Info;

            return true;
        }

    }
}
