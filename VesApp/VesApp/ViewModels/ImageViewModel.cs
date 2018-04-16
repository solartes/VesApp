using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using VesApp.Models;
using VesApp.Services;
using VesApp.Views;
using Xamarin.Forms;

namespace VesApp.ViewModels
{
    public class ImageViewModel : BaseViewModel
    {
        public ImageViewModel(){
            
        }

        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private List<Donation> donations;
        #endregion

        #region Properties
        public List<Donation> Donations
        {
            get
            {
                return this.donations;
            }

            set
            {
                SetValue(ref this.donations, value);
            }
        }
        #endregion



        #region Methods

        public async void LoadConfig()
        {
            if (Donations == null)
            {
                this.apiService = new ApiService();

                var connection = await this.apiService.CheckConnection();

                if (!connection.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
                    return;
                }


                var response = await this.apiService.GetList<Donation>(
                    "http://vesappapi.azurewebsites.net",
                    "/api",
                    "/Donations");

                if (!response.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                    return;
                }

                var list = (List<Donation>)response.Result;
                this.Donations = list;
            }
        }

        private void OnTapped(object s)
        {
            String accion = (string)s;
            if (accion.Equals("Facebook"))
            {
                try
                {
                    Device.OpenUri(new Uri(Donations[2].UrlDireccion));
                }
                catch
                {
                    Device.OpenUri(new Uri(Donations[2].UrlImagen));
                }
            }
            if (accion.Equals("Instagram"))
            {
                try
                {
                    Device.OpenUri(new Uri(Donations[1].UrlDireccion));
                }
                catch
                {
                    Device.OpenUri(new Uri(Donations[1].UrlImagen));
                }
            }            

        }

        #endregion

        #region Commands
        public ICommand OpenBrowser
        {
            get
            {
                return new RelayCommand<object>(OnTapped);
            }
        }
        #endregion

    }
}
