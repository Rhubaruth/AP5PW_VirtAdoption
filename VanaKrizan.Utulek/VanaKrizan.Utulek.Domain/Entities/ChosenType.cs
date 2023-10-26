using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public enum PetType {
        Error,
        Dog,
        Cat, 
        Rabbit,
    }

    public class ChosenType
    {
        public PetType Type { get; set; }
    }
}
