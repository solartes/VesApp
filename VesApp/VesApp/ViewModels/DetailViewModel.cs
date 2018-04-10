using System;
using System.Collections.Generic;
using System.Text;
using VesApp.Models;

namespace VesApp.ViewModels
{
    public class DetailViewModel
    {
        public Predication Predication { get; set; }
        public Reflexion Reflexion { get; set; }

        public DetailViewModel(Reflexion reflexion)
        {
            Reflexion = reflexion;
        }

        public DetailViewModel(Predication predication)
        {
            Predication = predication;
        }
    }
}
