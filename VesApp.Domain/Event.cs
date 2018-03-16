using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VesApp.Domain
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }
        public string Titulo { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Text { get; set; }        
        [DataType(DataType.Date)]
        [Index("Publication_Fecha_Index")]
        public DateTime FechaEvento { get; set; }
        public string EnlaceOnline;
        public string EnlaceInscripcion;
    }
}
