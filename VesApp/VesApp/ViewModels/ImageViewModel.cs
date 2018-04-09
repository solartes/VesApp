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
        #region Properties
        public List<ImageNavigate> Images { get; set; }
        #endregion

        #region Constructors
        public ImageViewModel()
        {
            this.Images = new List<ImageNavigate>
            {                
                new ImageNavigate
                {
                    Icon = "ic_instagram.png",
                    IconName = "Instagram",
                    PageRedirection = "Predicaciones",

                },
                new ImageNavigate
                {
                    Icon = "ic_facebook.png",
                    IconName = "Facebook",
                    PageRedirection = "Predicaciones",

                },
                new ImageNavigate
                {
                    Icon = "ic_telefono.png",
                    IconName = "Telefono",
                    PageRedirection = "",

                },
                new ImageNavigate
                {
                    Icon = "ic_casa.png",
                    IconName = "Casa",
                    PageRedirection = "",

                }            
            };
        }
        #endregion
       
    }
}
