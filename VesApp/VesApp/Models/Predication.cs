using System;

namespace VesApp.Models
{
    public class Predication
    {
        public int IdPredication { get; set; }
        public string Titulo { get; set; }
        public string Text { get; set; }
        public string UrlVideo { get; set; }
        public string UrlImagen { get; set; }
        public DateTime Fecha { get; set; }
        public string Sacerdote { get; set; }
    }
}
