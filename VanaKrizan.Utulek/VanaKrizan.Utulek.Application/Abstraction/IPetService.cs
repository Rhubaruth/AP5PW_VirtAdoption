using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;


namespace VanaKrizan.Utulek.Application.Abstraction
{
    public interface IPetService
    {
        IList<Pet> Select();
        Pet? SelectById(int id);

        void Create(Pet pet);
        bool Delete(int id);

        bool Edit(Pet pet);


    }
}
