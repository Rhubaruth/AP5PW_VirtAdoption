using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;

namespace VanaKrizan.Utulek.Application.Implementation
{
    public class HomeService : IHomeService
    {

        public CarouselProductViewModel GetHomeIndexViewModel(IPetService petService)
        {
            CarouselProductViewModel viewModel = new CarouselProductViewModel();
            viewModel.Pets = petService.Select();
            //viewModel.Carousels = DatabaseFake.Carousels;

            return viewModel;
        }

    }
}
