using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VesApp.Views;

namespace VesApp.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }        
        #endregion

        #region ViewModels
        public DetailViewModel DetailViewModel
        {
            get;
            set;
        }

        public PublicationViewModel PublicationViewModel
        {
            get;
            set;
        }

        public ImageViewModel ImageViewModel
        {
            get;
            set;
        }

        public EmailViewModel EmailViewModel
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;            
            this.PublicationViewModel = new PublicationViewModel();
            this.LoadMenu();
        }

        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>
            {
                /*new MenuItemViewModel
                {
                    Icon = "reflexion.png",
                    PageName = "ReflexionPage",
                    Title = "Reflexión del evangelio",

                },*/
                new MenuItemViewModel
                {
                    Icon = "ic_predicaciones.png",
                    PageName = "PredicationPage",
                    Title = "Predicaciones",

                },
                new MenuItemViewModel
                {
                    Icon = "ic_proyectos.png",
                    PageName = "ProjectPage",
                    Title = "Proyectos Sociales",

                },
                new MenuItemViewModel
                {
                    Icon = "ic_evento.png",
                    PageName = "EventPage",
                    Title = "Eventos",

                },
                new MenuItemViewModel
                {
                    Icon = "ic_redes.png",
                    PageName = "SocialMediaPage",
                    Title = "Redes Sociales",

                },
                new MenuItemViewModel
                {
                    Icon = "ic_peticiones.png",
                    PageName = "PetitionPage",
                    Title = "Peticiones",

                },
                new MenuItemViewModel
                {
                    Icon = "ic_contactenos.png",
                    PageName = "ContactPage",
                    Title = "Contáctenos",

                }
            };
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
