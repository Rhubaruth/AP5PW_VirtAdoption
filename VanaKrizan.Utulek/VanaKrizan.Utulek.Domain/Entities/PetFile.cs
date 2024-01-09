using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Domain.Entities;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public class PetFile
    {
        public Pet PetObj { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
