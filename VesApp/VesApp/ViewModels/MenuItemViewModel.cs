using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VesApp.Views;
using Xamarin.Forms;

namespace VesApp.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(NavigateAsync);
            }
        }

        private async void NavigateAsync()
        {
            App.Master.IsPresented = false;
            if (this.PageName == "ReflexionPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadReflexions();
                await App.Navigator.PushAsync(new ReflexionPage());
            }
            if (this.PageName == "PredicationPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadPredications();
                await App.Navigator.PushAsync(new PredicationPage());             
            }
            if (this.PageName == "ProjectPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadProjects();
                await App.Navigator.PushAsync(new ProjectPage());
            }
            if (this.PageName == "EventPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadEvents();
                await App.Navigator.PushAsync(new EventPage());
            }
            if (this.PageName == "SocialMediaPage")
            {
                MainViewModel.GetInstance().ImageViewModel = new ImageViewModel();
                MainViewModel.GetInstance().ImageViewModel.LoadConfig();
                await App.Navigator.PushAsync(new SocialMediaPage());
            }
            if (this.PageName == "PetitionPage")
            {
                MainViewModel.GetInstance().EmailViewModel = new EmailViewModel();
                await App.Navigator.PushAsync(new PetitionPage());
            }
            if (this.PageName == "ContactPage")
            {
                MainViewModel.GetInstance().EmailViewModel = new EmailViewModel();
                await App.Navigator.PushAsync(new ContactPage());
            }
        }
        #endregion
    }
}
