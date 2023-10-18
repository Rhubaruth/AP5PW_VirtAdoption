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
        public static List<Dog> Dogs {  get; set; }
        public static List<Cat> Cats {  get; set; }

        static DatabaseFake()
        {
            Pets = new List<Pet>();
            
            Dogs = new List<Dog>();
            Cats = new List<Cat>();


            Pets.Add(new Dog
            {
                Id = 1,
                Name = "Doggo",
                Sex = 'M',
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                Chip = false,
                SizeId = 1,
            });

            Pets.Add(new Dog
            {
                Id = 2,
                Name = "Oggod",
                Sex = 'M',
                InShelterSince = DateTime.Now,
                Chip = true,
                SizeId = 2,
            });

            Pets.Add(new Cat
            {
                Id = 3,
                Name = "Kitty",
                Birth = DateTime.Now,
                Chip = true,
            });

        }

        public static List<Pet> SelectAll()
        {
            List<Pet> concatPets = new();
            concatPets.Clear();
            foreach(var pet in Dogs) {
                concatPets.Add(pet);
            }
            foreach (var pet in Cats)
            {
                concatPets.Add(pet);
            }

            return concatPets;
        }

    }
}
