using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VesApp.Views;
using Xamarin.Forms;

namespace VesApp.ViewModels
{
    public class ImageNavigate
    {
        #region Properties
        public string Icon { get; set; }
        public string IconName { get; set; }
        public string PageRedirection { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(OpenWeb);
            }
        }

        private void OpenWeb()
        {
            if (this.IconName == "Instagram")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadReflexions();
                App.Navigator.PushAsync(new ReflexionPage());
            }
            if (this.IconName == "Facebook")
            {
                MainViewModel.GetInstance().PublicationViewModel.LoadPredications();
                App.Navigator.PushAsync(new PredicationPage());
            }           
        }
        #endregion
    }
}
