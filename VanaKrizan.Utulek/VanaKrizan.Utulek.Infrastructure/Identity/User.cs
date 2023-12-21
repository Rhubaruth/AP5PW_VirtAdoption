using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VanaKrizan.Utulek.Domain.Entities.Interface;

namespace VanaKrizan.Utulek.Infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}
