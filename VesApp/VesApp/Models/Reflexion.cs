using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using VesApp.ViewModels;
using VesApp.Views;
using Xamarin.Forms;

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
        }

        public ICommand OpenLinkCommand
        {
            get
            {
                return new RelayCommand(OpenLink);
            }
        }

        void OpenLink()
        {
            try
            {
                string urlVideo = this.UrlVideo;
                int index = urlVideo.LastIndexOf('/');
                String idVideo = urlVideo.Substring(index + 1);
                String video= "watch?v="+idVideo;
                Device.OpenUri(new Uri("vnd.youtube://"+video));
            }
            catch
            {
                Device.OpenUri(new Uri(this.UrlVideo));
            }
        }
        #endregion
    }
}
