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
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            App.Master.IsPresented = false;
            if (this.PageName == "ReflexionPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadReflexions();
                App.Navigator.PushAsync(new ReflexionPage());
            }
            if (this.PageName == "PredicationPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadPredications();
                App.Navigator.PushAsync(new PredicationPage());             
            }
            if (this.PageName == "ProjectPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadProjects();
                App.Navigator.PushAsync(new ProjectPage());
            }
            if (this.PageName == "EventPage")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadEvents();
                App.Navigator.PushAsync(new EventPage());
            }
            if (this.PageName == "SocialMediaPage")
            {
                //MainViewModel.GetInstance().PublicationViewModel.LoadPredications();
                App.Navigator.PushAsync(new SocialMediaPage());
            }
            if (this.PageName == "PetitionPage")
            {
                //MainViewModel.GetInstance().PublicationViewModel.LoadPredications();
                App.Navigator.PushAsync(new PetitionPage());
            }
            if (this.PageName == "ContactPage")
            {
                //MainViewModel.GetInstance().PublicationViewModel.LoadPredications();
                App.Navigator.PushAsync(new ContactPage());
            }
        }
        #endregion
    }
}
