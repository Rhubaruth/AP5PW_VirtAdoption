using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Application.ViewModels
{
    public class CarouselPetViewModel
    {
        public IList<PetConjoined> PetsConj { get; set; } = new List<PetConjoined>();
    }
}
