﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VesApp.Domain
{
    public class Reflexion
    {
        [Key]
        public int IdReflexion { get; set; }
        public string Titulo { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Text { get; set; }
        public string UrlVideo { get; set; }
        public string UrlImagen { get; set; }        
        [DataType(DataType.Date)]
        [Index("Reflexion_Fecha_Index")]
        public DateTime Fecha { get; set; }
        public string Sacerdote { get; set; }
    }
}
