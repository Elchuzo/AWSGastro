using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GastroAvancesWeb.Models
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetRoleClaim = new HashSet<AspNetRoleClaim>();
            AspNetUserRole = new HashSet<AspNetUserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaim { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRole { get; set; }
    }
}
