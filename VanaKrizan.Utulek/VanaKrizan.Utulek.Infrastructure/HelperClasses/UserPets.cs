using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Infrastructure.HelperClasses
{
    public class UserPets
    {
        public int UserId { get; set; }

        public IList<Pet> adoptedPets {  get; set; }
        public IList<Pet> otherPets { get; set; }

        public int addPetId { get; set; }
        public int removePetId { get; set;}

    }
}
