using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VesApp.Models;
using VesApp.Services;
using Xamarin.Forms;

namespace VesApp.ViewModels
{
    public class ReflexionViewModel:BaseViewModel
    {

        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Publication> publications;
        #endregion

        #region Properties
        public ObservableCollection<Publication> Publications
        {
            get
            {
                return this.publications;
            }

            set
            {
                SetValue(ref this.publications, value);
            }
        }
        #endregion

        #region Constructors
        public ReflexionViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPublications();
        }
        #endregion

        #region Methods
        private async void LoadPublications()
        {
            var response = await this.apiService.GetList<Publication>(
                "http://vesappapi.azurewebsites.net",
                "/api",
                "/Publications");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error",response.Message,"Aceptar");
                return;
            }

            var list = (List<Publication>)response.Result;
            this.Publications = new ObservableCollection<Publication>(list);
            
        }    
        #endregion

    }
}
