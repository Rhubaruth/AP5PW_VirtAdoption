using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public List<Pet> GetPets() 
        { 
            
            List<Pet> pets = new List<Pet>();

            #region Hardcoded adding pets
            pets.Add(new Dog
            {
                Id = 1,
                Name = "Doggo",
                Sex = 'M',
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                Chip = false,
                SizeId = 1,
                ImageSrc = "/img/pets/peso1.jpg",
            });

            pets.Add(new Dog
            {
                Id = 2,
                Name = "Oggod",
                Sex = 'M',
                InShelterSince = DateTime.Now,
                Chip = true,
                SizeId = 2,
                ImageSrc = "/img/pets/peso2.jpg",
            });

            pets.Add(new Cat
            {
                Id = 3,
                Name = "Kitty",
                Birth = DateTime.Now,
                Chip = true,
                ImageSrc = "/img/pets/kocka1.jpg",
            });
            #endregion

            return pets;
        }

        public List<Pet> GetCarousels()
        {
            List<Pet> carousel = new List<Pet>();

            #region Hardcoded adding
            carousel.Add(new Cat
            {
                Id = 1,
                Name = "ahoj",
                Sex = 'M',
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                Chip = false,
                ImageSrc = "/img/carousel/produkty-08.jpg",
            });

            carousel.Add(new Pet
            {
                Id = 1,
                Name = "xd",
                Sex = 'M',
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                ImageSrc = "/img/carousel/produkty-09.jpg",
            });

            carousel.Add(new Pet
            {
                Id = 1,
                Name = "riii",
                Sex = 'F',
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                ImageSrc = "/img/pets/produkty-03.jpg",
            });
            #endregion

            return carousel;
        }

    }
}
