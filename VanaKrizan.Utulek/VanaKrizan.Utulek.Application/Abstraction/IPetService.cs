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
        IList<Pet> PetSelectAll();
        Pet? PetSelectById(int id);
        void PetCreate(Pet pet);
        bool PetDelete(int id);
        bool PetEdit(Pet pet);

        public IList<Size> SizeSelectAll();
        public Size? SizeSelectById(int? id);

        public IList<Breed> BreedSelectAll();
        public Breed? BreedSelectById(int? id);

    }
}
