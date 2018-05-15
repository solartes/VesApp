using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VesApp.Models;
using Xamarin.Forms;

namespace VesApp.ViewModels
{
    public class DetailViewModel
    {
        public Predication Predication { get; set; }
        public Reflexion Reflexion { get; set; }
        public Project Project { get; set; }
        public Event Evento { get; set; }

        public DetailViewModel()
        {
        }

        public DetailViewModel(Reflexion reflexion)
        {
            Reflexion = reflexion;
        }

        public DetailViewModel(Predication predication)
        {
            Predication = predication;
        }

        public DetailViewModel(Project project)
        {
            Project = project;
        }

        public DetailViewModel(Event evento)
        {
            Evento = evento;
        }

        public ICommand DonarCommand
        {
            get
            {
                return new RelayCommand(Donar);
            }
        }

        void Donar()
        {
            Device.OpenUri(new Uri(MainViewModel.GetInstance().ImageViewModel.Donations[0].UrlDireccion));
        }
    }
}
