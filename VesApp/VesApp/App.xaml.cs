using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VesApp.Views;
using Xamarin.Forms;

namespace VesApp
{
	public partial class App : Application
	{
        #region Properties
        public static NavigationPage Navigator { get; set; }
        #endregion

        #region Constructors
        public App ()
		{
			InitializeComponent();
            MainPage = new MasterPage();
            //MainPage = new NavigationPage(new ReflexionPage());
        }
        #endregion

        #region Methods
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        #endregion
    }
}
