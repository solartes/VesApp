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
        private ObservableCollection<Reflexion> reflexions;
        #endregion

        #region Properties
        public ObservableCollection<Reflexion> Reflexions
        {
            get
            {
                return this.reflexions;
            }

            set
            {
                SetValue(ref this.reflexions, value);
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
            var response = await this.apiService.GetList<Reflexion>(
                "http://vesappapi.azurewebsites.net",
                "/api",
                "/Reflexions");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error",response.Message,"Aceptar");
                return;
            }

            var list = (List<Reflexion>)response.Result;
            this.Reflexions = new ObservableCollection<Reflexion>(list);
            
        }    
        #endregion

    }
}
