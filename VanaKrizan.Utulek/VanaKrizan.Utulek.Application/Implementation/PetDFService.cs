//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VanaKrizan.Utulek.Application.Abstraction;
//using VanaKrizan.Utulek.Domain.Entities;
//using VanaKrizan.Utulek.Infrastructure.Database;

//namespace VanaKrizan.Utulek.Application.Implementation
//{
//    public class PetDFService : IPetService
//    {
//        IList<Pet> IPetService.PetSelectAll()
//        {
//            return DatabaseFake.Pets;
//        }

//        Pet? IPetService.PetSelectById(int id)
//        {
//            foreach(Pet pet in DatabaseFake.Pets)
//            {
//                if(pet.Id == id) return pet;
//            }
//            return null;
//        }

//        public void PetCreate(Pet pet)
//        {
//            // fake id
//            if (DatabaseFake.Pets != null && DatabaseFake.Pets.Count > 0) {
//                pet.Id = DatabaseFake.Pets.Last().Id + 1;
//            }
//            else
//            {
//                pet.Id = 1;
//            }

//            // add to DatabaseFake
//            if (DatabaseFake.Pets == null)
//                return;
//            DatabaseFake.Pets.Add(pet);
//        }

//        public bool PetDelete(int id)
//        {
//            bool deleted = false;

//            Pet? pet = DatabaseFake.Pets.FirstOrDefault(prod => prod.Id == id);
//            if (pet != null)
//            {
//                deleted = DatabaseFake.Pets.Remove(pet);
//            }


//            return deleted;
//        }

//        public bool PetEdit(Pet pet)
//        {
//            bool _isEdited = false;

//            Pet? existingPet = DatabaseFake.Pets.FirstOrDefault(p => p.Id == pet.Id);
//            if (existingPet == null)
//                return false;

//            existingPet.Name = pet.Name;
//            existingPet.Birth = pet.Birth;
//            existingPet.Sex = pet.Sex;
//            existingPet.Info = pet.Info;

//            return true;
//        }

//        void IPetService.PetCreate(Pet pet)
//        {
//            throw new NotImplementedException();
//        }

//        bool IPetService.PetDelete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        bool IPetService.PetEdit(Pet pet)
//        {
//            throw new NotImplementedException();
//        }

//        IList<Size> IPetService.SizeSelectAll()
//        {
//            throw new NotImplementedException();
//        }

//        Size? IPetService.SizeSelectById(int? id)
//        {
//            throw new NotImplementedException();
//        }

//        IList<Breed> IPetService.BreedSelectAll()
//        {
//            throw new NotImplementedException();
//        }

//        Breed? IPetService.BreedSelectById(int? id)
//        {
//            throw new NotImplementedException();
//        }

//        public IList<Pet> UserGetPetsAll(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
