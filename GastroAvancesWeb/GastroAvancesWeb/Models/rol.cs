using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GastroAvancesWeb.Models
{
    public partial class rol : IdentityRole
    {
        public int id_rol { get; set; }
        public string descripcion { get; set; }
    }
}
