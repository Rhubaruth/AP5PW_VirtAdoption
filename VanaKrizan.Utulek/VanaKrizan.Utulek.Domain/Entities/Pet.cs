using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public class Pet: Entity<int>
    {
        [Required]
        public string Name { get; set; }
        public DateTime? Birth { get; set; }

        //[ForeignKey(nameof(Pet))]
        public int? BreedId { get; set; }

        [StringLength(1)]
        public string? Sex { get; set; }

        [Required]
        public DateTime InShelterSince { get; set; }

        // public double Cost { get; set; }

        [Required]
        public string ImageSrc { get; set; }
        public string? Info { get; set; }

        



    }
}
