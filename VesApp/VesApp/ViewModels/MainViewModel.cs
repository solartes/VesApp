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
        public ReflexionViewModel Reflexion
        {
            get;
            set;
        }

   
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;            
            this.Reflexion = new ReflexionViewModel();
            this.LoadMenu();
        }

        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Icon = "reflexion.png",
                    PageName = "ReflexionPage",
                    Title = "Reflexión del evangelio",

                },
                new MenuItemViewModel
                {
                    Icon = "predicaciones.png",
                    PageName = "PredicationPage",
                    Title = "Predicaciones",

                },
                new MenuItemViewModel
                {
                    Icon = "proyectos.png",
                    PageName = "ProyectoPage",
                    Title = "Proyectos Sociales",

                },
                new MenuItemViewModel
                {
                    Icon = "evento.png",
                    PageName = "ProyectoPage",
                    Title = "Eventos",

                },
                new MenuItemViewModel
                {
                    Icon = "redes.png",
                    PageName = "ProyectoPage",
                    Title = "Redes Sociales",

                },
                new MenuItemViewModel
                {
                    Icon = "peticiones.png",
                    PageName = "ProyectoPage",
                    Title = "Peticiones",

                },
                new MenuItemViewModel
                {
                    Icon = "contactenos.png",
                    PageName = "ProyectoPage",
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
