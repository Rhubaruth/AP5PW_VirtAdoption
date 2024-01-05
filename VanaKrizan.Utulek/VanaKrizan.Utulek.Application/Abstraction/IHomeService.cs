using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Application.Abstraction
{
    public interface IHomeService
    {

        CarouselProductViewModel GetHomeIndexViewModel(IPetService petService);
    }
}
