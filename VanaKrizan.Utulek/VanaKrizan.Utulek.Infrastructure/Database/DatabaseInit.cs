using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;


namespace VanaKrizan.Utulek.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public List<Pet> GetPets() 
        { 
            
            List<Pet> pets = new List<Pet>();

            #region Hardcoded adding pets
            pets.Add(new Pet
            {
                Id = 1,
                Name = "Doggo",
                Sex = "M",
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                //Chip = false,
                //SizeId = 1,
                ImageSrc = "/img/pets/peso1.jpg",
            });

            pets.Add(new Pet
            {
                Id = 2,
                Name = "Oggod",
                Sex = "M",
                InShelterSince = DateTime.Now,
                //Chip = true,
                //SizeId = 2,
                ImageSrc = "/img/pets/peso2.jpg",
            });

            pets.Add(new Pet
            {
                Id = 3,
                Name = "Kitty",
                Birth = DateTime.Now,
                //Chip = true,
                ImageSrc = "/img/pets/kocka1.jpg",
            });
            #endregion

            return pets;
        }

        public List<Pet> GetCarousels()
        {
            List<Pet> carousel = new List<Pet>();

            #region Hardcoded adding to carouslels
            carousel.Add(new Pet
            {
                Id = 1,
                Name = "ahoj",
                Sex = "M",
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                //Chip = false,
                ImageSrc = "/img/carousel/produkty-08.jpg",
            });

            carousel.Add(new Pet
            {
                Id = 1,
                Name = "xd",
                Sex = "M",
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                ImageSrc = "/img/carousel/produkty-09.jpg",
            });

            carousel.Add(new Pet
            {
                Id = 1,
                Name = "riii",
                Sex = "F",
                Birth = DateTime.Now,
                InShelterSince = DateTime.Now,
                ImageSrc = "/img/pets/produkty-03.jpg",
            });
            #endregion

            return carousel;
        }

        public List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>();

            #region Create roles
            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role roleCustomer = new Role()
            {
                Id = 3,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };
            #endregion

            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(roleCustomer);
            

            return roles;
        }

        public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
        {
            User admin = new User()
            {
                #region Admin Data
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
                #endregion
            };

            // propojení s rolemi Admin, Manager a User
            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return (admin, adminUserRoles);
        }

        public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
        {
            User manager = new User()
            {
                #region Manager Data
                Id = 2,
                FirstName = "Managerek",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
                #endregion
            };

            // propojení s rolemi Manager a User
            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return (manager, managerUserRoles);
        }


        public List<Size> GetSizes()
        {
            List<Size> sizes = new List<Size>();

            #region Hardcoded adding sizes
            sizes.Add(new Size
            {
                Id = -1,
                Name = "Nezadáno",
            });
            sizes.Add(new Size
            {
                Id = 1,
                Name = "malá",
            });
            sizes.Add(new Size
            {
                Id = 2,
                Name = "střední",
            });
            sizes.Add(new Size
            {
                Id = 3,
                Name = "velká",
            });
            #endregion

            return sizes;
        }

    }
}
