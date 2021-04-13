using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GastroAvancesWeb.Models
{
    public partial class retiro
    {
        [Key]
        public int id_retiro { get; set; }
        public int? id_usuario { get; set; }
        [Display(Name = "Producto")]
        public int? id_producto { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? fecha { get; set; }
        [Display(Name = "Cantidad Inicial")]
        public int? cantidad_inicial { get; set; }
        [Display(Name = "Cantidad Retirada")]
        public int? cantidad_retirada { get; set; }
        [Display(Name = "Cantidad Final")]
        public int? cantidad_final { get; set; }

        [NotMapped]
        [Display(Name = "Usuario")]
        public string? nombre_usuario { get; set; }

        [ForeignKey("id_producto")]
        public producto id_productoNavigation { get; set; }
        [ForeignKey("id_usuario")]
        [NotMapped]
        [JsonIgnore]
        public AspNetUser id_usuarioNavigation { get; set; }
    }
}
