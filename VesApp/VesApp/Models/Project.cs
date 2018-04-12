using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VesApp.ViewModels;
using VesApp.Views;
using Xamarin.Forms;

namespace VesApp.Models
{
    public class Project
    {
        public int IdProject { get; set; }
        public string UrlVideo { get; set; }
        public string UrlImagen { get; set; }
        public string Text { get; set; }
        public string Titulo { get; set; }

        #region Commands
        public ICommand SelectProjectCommand
        {
            get
            {
                return new RelayCommand(SelectProject);
            }
        }

        async void SelectProject()
        {
            MainViewModel.GetInstance().DetailViewModel = new DetailViewModel(project: this);
            await App.Navigator.PushAsync(new DetailProjectPage());            
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
