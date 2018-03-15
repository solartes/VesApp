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
            if (this.PageName == "ReflexionPage")
            {
                Console.WriteLine("Reflexion");
            }
            if (this.PageName == "PredicationPage")
            {
                //MainViewModel.GetInstance.Clase= new clase();
                //Application.Current.MainPage = new PredicationPage();
                //Application.Current.MainPage.Navigation.PushAsync(new PredicationPage());
                App.Navigator.PushAsync(new PredicationPage());
            }
        }
        #endregion
    }
}
