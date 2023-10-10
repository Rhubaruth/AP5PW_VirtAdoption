using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public class Pet
    {
        protected string Name { get; set; }
        protected DateTime Birth { get; set; }
        protected int BreedId { get; set; }
        protected char Sex { get; set; }

        protected DateTime InShelterSince { get; set; }

        // public double Cost { get; set; }

        protected string ImageSrc { get; set; }
        protected string Info { get; set; }

        



    }
}
