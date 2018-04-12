﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using VesApp.Models;
using VesApp.Services;
using Xamarin.Forms;

namespace VesApp.ViewModels
{
    public class PublicationViewModel:BaseViewModel
    {

        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Reflexion> reflexions;
        private ObservableCollection<Predication> predications;
        private ObservableCollection<Project> projects;
        private ObservableCollection<Event> events;
        private bool isRefreshing;
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

        public ObservableCollection<Predication> Predications
        {
            get
            {
                return this.predications;
            }

            set
            {
                SetValue(ref this.predications, value);
            }
        }

        public ObservableCollection<Project> Projects
        {
            get
            {
                return this.projects;
            }

            set
            {
                SetValue(ref this.projects, value);
            }
        }

        public ObservableCollection<Event> Events
        {
            get
            {
                return this.events;
            }

            set
            {
                SetValue(ref this.events, value);
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                SetValue(ref this.isRefreshing, value);
            }
        }
        #endregion

        #region Constructors
        public PublicationViewModel()
        {
            this.apiService = new ApiService();
            this.LoadReflexions();
        }
        #endregion

        #region Methods
        public async void LoadReflexions()
        {
            this.IsRefreshing = true;
            /*
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");                
                return;
            }
            */

            var response = await this.apiService.GetList<Reflexion>(
                "http://vesappapi.azurewebsites.net",
                "/api",
                "/Reflexions");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error",response.Message,"Aceptar");
                return;
            }

            var list = (List<Reflexion>)response.Result;
            this.Reflexions = new ObservableCollection<Reflexion>(list);
            this.IsRefreshing = false;
        }

        public async void LoadPredications()
        {
            this.IsRefreshing = true;
            /*
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");                
                return;
            }
            */

            var response = await this.apiService.GetList<Predication>(
                "http://vesappapi.azurewebsites.net",
                "/api",
                "/Predications");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<Predication>)response.Result;
            this.Predications = new ObservableCollection<Predication>(list);
            this.IsRefreshing = false;
        }

        public async void LoadProjects()
        {
            this.IsRefreshing = true;
            /*
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");                
                return;
            }
            */

            var response = await this.apiService.GetList<Project>(
                "http://vesappapi.azurewebsites.net",
                "/api",
                "/Projects");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<Project>)response.Result;
            this.Projects = new ObservableCollection<Project>(list);
            this.IsRefreshing = false;
        }

        public async void LoadEvents()
        {
            this.IsRefreshing = true;
            /*
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");                
                return;
            }
            */

            var response = await this.apiService.GetList<Event>(
                "http://vesappapi.azurewebsites.net",
                "/api",
                "/Events");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<Event>)response.Result;
            this.Events = new ObservableCollection<Event>(list);
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public ICommand DonarCommand
        {
            get
            {
                return new RelayCommand(Donar);
            }
        }

        void Donar()
        {
            Device.OpenUri(new Uri("https://www.paypal.me/valorart"));
        }

        public ICommand RefreshReflexionsCommand
        {
            get
            {
                return new RelayCommand(LoadReflexions);
            }
        }

        public ICommand RefreshPredicationsCommand
        {
            get
            {
                return new RelayCommand(LoadPredications);
            }
        }

        public ICommand RefreshProjectsCommand
        {
            get
            {
                return new RelayCommand(LoadProjects);
            }
        }

        public ICommand RefreshEventsCommand
        {
            get
            {
                return new RelayCommand(LoadEvents);
            }
        }
        #endregion
    }
}
