﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VesApp.Models
{
    public class Publication
    {        
        public int IdPublicacion { get; set; }    
        public string UrlVideo { get; set; }        
        public object UrlImagen { get; set; }        
        public string Text { get; set; }        
        public string Titulo { get; set; }        
        public DateTime Fecha { get; set; }        
        public string Sacerdote { get; set; }
    }
}
