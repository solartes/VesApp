using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesApp.Domain
{
    public class Donation
    {
        [Key]
        public int IdDonation { get; set; }
        public string Text { get; set; }
        public string UrlDireccion { get; set; }
        public string UrlImagen { get; set; }
    }
}
