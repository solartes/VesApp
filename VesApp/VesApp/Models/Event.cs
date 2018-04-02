using System;
using System.Collections.Generic;
using System.Text;

namespace VesApp.Models
{
    public class Event
    {
        public int IdEvent { get; set; }
        public string Titulo { get; set; }
        public string Text { get; set; }
        public DateTime FechaEvento { get; set; }
        public string EnlaceOnline { get; set; }
        public string EnlaceInscripcion { get; set; }
        public string Lugar { get; set; }
    }
}
