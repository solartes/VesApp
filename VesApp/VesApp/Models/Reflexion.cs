using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using VesApp.ViewModels;
using VesApp.Views;

namespace VesApp.Models
{
    public class Reflexion
    {        
        public int IdPublicacion { get; set; }    
        public string UrlVideo { get; set; }        
        public object UrlImagen { get; set; }        
        public string Text { get; set; }        
        public string Titulo { get; set; }        
        public DateTime Fecha { get; set; }        
        public string Sacerdote { get; set; }

        #region Commands
        public ICommand SelectReflexionCommand
        {
            get
            {
                return new RelayCommand(SelectReflexionAsync);
            }
        }

        async void SelectReflexionAsync()
        {
            MainViewModel.GetInstance().DetailViewModel = new DetailViewModel(reflexion: this);
            await App.Navigator.PushAsync(new DetailReflexionPage());
            //Enviar this a el otro viewmodel
        }
        #endregion
    }
}
