using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Application.ViewModels
{
    public class CarouselProductViewModel
    {
        public IList<Pet> Carousels { get; set; }   // should be list of Carousels
        public IList<Pet>? Pets { get; set; }

    }
}
