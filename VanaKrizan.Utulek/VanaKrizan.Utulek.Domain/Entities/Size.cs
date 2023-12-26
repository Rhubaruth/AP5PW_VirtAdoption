using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public class Size: Entity<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
