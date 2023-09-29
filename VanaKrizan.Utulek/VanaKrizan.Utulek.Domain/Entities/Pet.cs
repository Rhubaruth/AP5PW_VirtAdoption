using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Domain.Entities
{
    interface Pet
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public int BreedId { get; set; }
        public char Sex { get; set; }

        public DateTime InShelterSince { get; set; }

        // public double Cost { get; set; }

        public string ImageSrc { get; set; }
        public string Info { get; set; }

        



    }
}
