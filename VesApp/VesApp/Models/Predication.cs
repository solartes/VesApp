using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using VesApp.ViewModels;
using VesApp.Views;
using Xamarin.Forms;

namespace VesApp.Models
{
    public class Predication
    {
        #region Properties
        public int IdPredication { get; set; }
        public string Titulo { get; set; }
        public string Text { get; set; }
        public string UrlVideo { get; set; }
        public string UrlImagen { get; set; }
        public DateTime Fecha { get; set; }
        public string Sacerdote { get; set; } 
        #endregion

        #region Commands
        public ICommand SelectPredicationCommand
        {
            get
            {
                return new RelayCommand(SelectPredication);
            }
        }

        async void SelectPredication()
        {
            MainViewModel.GetInstance().DetailViewModel = new DetailViewModel(predication: this);
            await App.Navigator.PushAsync(new DetailPredicationPage());            
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
                String video = "watch?v=" + idVideo;
                Device.OpenUri(new Uri("vnd.youtube://" + video));
            }
            catch (Exception e)
            {
                Device.OpenUri(new Uri(this.UrlVideo));
            }
        }
        #endregion
    }
}
