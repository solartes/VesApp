﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProjectPage : ContentPage
	{
		public ProjectPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            MainViewModel.GetInstance().PublicationViewModel.LoadRefreshProjects();
        }
    }
}