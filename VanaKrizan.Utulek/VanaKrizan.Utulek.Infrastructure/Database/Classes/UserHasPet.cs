using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Identity;


namespace VanaKrizan.Utulek.Infrastructure.Database.Classes
{
    public class UserHasPet: Entity<int>
    {
        [ForeignKey(nameof(User.Id))]
        public int UserId { get; set; }

        [ForeignKey(nameof(Pet.Id))]
        public int PetId { get; set; }

    }
}
