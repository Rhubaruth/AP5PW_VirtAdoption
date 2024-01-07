using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public class PetConjoined
    {
        public Pet pet { get; set; }
        public Size size { get; set; }
        public Breed breed { get; set; }

        public double? cost { get; set; }

        public PetConjoined(Pet _pet, Size _size, Breed _breed) 
        { 
            this.pet = _pet;
            this.size = _size;
            this.breed = _breed;
        }
    }
}
