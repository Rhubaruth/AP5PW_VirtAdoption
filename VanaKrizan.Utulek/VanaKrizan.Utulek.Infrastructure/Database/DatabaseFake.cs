using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Pet> Pets {  get; set; }

        static DatabaseFake()
        {
            Pets= new List<Pet>();

            Pets.Add(new Pet {
                Id = 1,
                Name = "Test Rat",
                Sex = 'M',
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
            });
            Pets.Add(new Pet
            {
                Id = 2,
                Name = "Test Rat 2",
                Sex = 'F',
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
            });
        }

    }
}
