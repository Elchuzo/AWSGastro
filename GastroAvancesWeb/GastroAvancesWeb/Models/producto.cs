using GastroAvancesWeb.Extensiones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
//using System.Text.Json.Serialization;
using ZXing;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GastroAvancesWeb.Models
{
    public partial class producto
    {
        public producto()
        {
            retiro = new HashSet<retiro>();
        }

        [Key]
        public int id_producto { get; set; }
        [JsonIgnore]
        [Display(Name = "Nombre Producto")]
        public string nombre { get; set; }
        [JsonIgnore]
        [Display(Name = "Precio Unitario")]
        public decimal? precio_unitario { get; set; }
        [JsonIgnore]
        [Display(Name = "Cantidad Disponible")]
        public int? cantidad { get; set; }
        [JsonIgnore]
        [NotMapped]
        public byte[] codigo_qr { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int retirado { get; set; }

        public byte[] generarQR()
        {
            var escritorQR = new BarcodeWriter();
            escritorQR.Format = BarcodeFormat.QR_CODE;
            escritorQR.Options.Width = 500;
            escritorQR.Options.Height = 500;
            string json = JsonConvert.SerializeObject(this);
            var result = escritorQR.Write(json);
            System.Console.WriteLine(json);
            var bitmapQR = new Bitmap(result);
            byte[] codigo_qr = bitmapQR.ToByteArray(ImageFormat.Bmp);
            return codigo_qr;
            //var converter = new ImageConverter();
        }
        [ForeignKey("retiro")]
        [NotMapped]
        public ICollection<retiro> retiro { get; set; }
    }
}
