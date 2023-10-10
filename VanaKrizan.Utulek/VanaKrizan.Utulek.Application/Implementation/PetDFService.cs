using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Domain.Entities;
using VanaKrizan.Utulek.Infrastructure.Database;

namespace VanaKrizan.Utulek.Application.Implementation
{
    public class PetDFService : IPetService
    {
        IList<Pet> IPetService.Select()
        {
            return DatabaseFake.Pets;
        }
    }
}
