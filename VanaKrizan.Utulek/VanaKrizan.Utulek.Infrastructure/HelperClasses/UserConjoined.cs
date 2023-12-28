using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanaKrizan.Utulek.Infrastructure.Identity;
using VanaKrizan.Utulek.Infrastructure.Identity.Enums;

namespace VanaKrizan.Utulek.Domain.Entities
{
    public class UserConjoined
    {
        public User User { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool IsCustomer { get; set; }
    }
}
