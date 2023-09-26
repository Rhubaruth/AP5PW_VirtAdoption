using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public class Dog : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }




    }
}
