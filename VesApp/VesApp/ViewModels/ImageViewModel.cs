using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using VesApp.Views;
using Xamarin.Forms;

namespace VesApp.ViewModels
{
    public class ImageViewModel
    {
        public ImageViewModel(){
            
        }

        #region Methods
        private void OnTapped(object s)
        {
            String accion = (string)s;
            if (accion.Equals("Facebook"))
            {
                try
                {
                    Device.OpenUri(new Uri("fb://page/253070561537771"));
                }
                catch (Exception e)
                {
                    Device.OpenUri(new Uri("https://www.facebook.com/valorartsantamarta/"));
                }
            }
            if (accion.Equals("Instagram"))
            {
                try
                {
                    Device.OpenUri(new Uri("instagram://user?username=valorart_"));
                }
                catch (Exception e)
                {
                    Device.OpenUri(new Uri("https://www.instagram.com/valorart_/"));
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
