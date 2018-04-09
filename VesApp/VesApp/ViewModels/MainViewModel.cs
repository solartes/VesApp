using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace VesApp.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }        
        #endregion

        #region ViewModels
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
                    Icon = "predicaciones.png",
                    PageName = "PredicationPage",
                    Title = "Predicaciones",

                },
                new MenuItemViewModel
                {
                    Icon = "proyectos.png",
                    PageName = "ProjectPage",
                    Title = "Proyectos Sociales",

                },
                new MenuItemViewModel
                {
                    Icon = "evento.png",
                    PageName = "EventPage",
                    Title = "Eventos",

                },
                new MenuItemViewModel
                {
                    Icon = "redes.png",
                    PageName = "SocialMediaPage",
                    Title = "Redes Sociales",

                },
                new MenuItemViewModel
                {
                    Icon = "peticiones.png",
                    PageName = "PetitionPage",
                    Title = "Peticiones",

                },
                new MenuItemViewModel
                {
                    Icon = "contactenos.png",
                    PageName = "ContactPage",
                    Title = "Contactenos",

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
