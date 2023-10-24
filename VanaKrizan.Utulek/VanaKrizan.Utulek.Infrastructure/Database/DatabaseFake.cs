using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;

namespace VanaKrizan.Utulek.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Pet> Pets {  get; set; }
        public static List<Dog> Dogs {  get; set; }
        public static List<Cat> Cats {  get; set; }

        public static List<Pet> Carousels { get; set; }

        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();

            Pets = dbInit.GetPets();
            Carousels = dbInit.GetCarousels();

            //Dogs = new List<Dog>();
            //Cats = new List<Cat>();




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
