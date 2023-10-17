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

    }
}
