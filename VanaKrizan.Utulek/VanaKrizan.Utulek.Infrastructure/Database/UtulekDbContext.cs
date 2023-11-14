using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Infrastructure.Database
{
    public class UtulekDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public UtulekDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();
            modelBuilder.Entity<Pet>().HasData(dbInit.GetPets());

            // nevkládá se neustále, pouze poprvé za migraci

        }

    }
}
