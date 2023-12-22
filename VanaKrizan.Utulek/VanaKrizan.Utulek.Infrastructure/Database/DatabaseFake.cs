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

        public static List<Pet> Carousels { get; set; }

        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();

            Pets = dbInit.GetPets();
            Carousels = dbInit.GetCarousels();

        }

        public static List<Pet> SelectAll()
        {
            return Pets;
        }

    }
}
