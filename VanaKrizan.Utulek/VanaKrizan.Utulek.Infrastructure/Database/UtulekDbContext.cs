﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;
using VanaKrizan.Utulek.Infrastructure.Database.Classes;


namespace VanaKrizan.Utulek.Infrastructure.Database
{
    public class UtulekDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<UserHasPet> UserHasPet {  get; set; }


        public UtulekDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();
            // nevkládá se neustále, pouze poprvé za migraci
            modelBuilder.Entity<Size>().HasData(dbInit.GetSizes());
            modelBuilder.Entity<Breed>();
            modelBuilder.Entity<Pet>().HasData(dbInit.GetPets());



            //Identity - User and Role initialization
            //roles must be added first
            modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

            //then, create users ..
            (User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, manager);

            //and finally, connect the users with the roles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);


            // connect User and Pets
            modelBuilder.Entity<UserHasPet>().HasData(dbInit.CreateUserWithPet());


            //configuration of User entity using IUser interface property inside Order entity
            // modelBuilder.Entity<Order>().HasOne<User>(e => e.User as User);

        }

    }
}
