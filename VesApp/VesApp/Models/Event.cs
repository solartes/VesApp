﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VesApp.ViewModels;
using VesApp.Views;
using Xamarin.Forms;

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
        public string Hora { get; set; }

        #region Commands
        public ICommand SelectEventCommand
        {
            get
            {
                return new RelayCommand(SelectEvent);
            }
        }

        async void SelectEvent()
        {
            MainViewModel.GetInstance().DetailViewModel = new DetailViewModel(evento: this);
            await App.Navigator.PushAsync(new DetailEventPage());            
        }

        public ICommand OpenOnlineCommand
        {
            get
            {
                return new RelayCommand(OpenOnline);
            }
        }

        void OpenOnline()
        {
                Device.OpenUri(new Uri(this.EnlaceOnline));            
        }

        public ICommand OpenInscripcionCommand
        {
            get
            {
                return new RelayCommand(OpenInscripcion);
            }
        }

        void OpenInscripcion()
        {
            Device.OpenUri(new Uri(this.EnlaceInscripcion));
        }
        #endregion
    }
}
