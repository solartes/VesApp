using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace VesApp.ViewModels
{
    public class EmailViewModel:BaseViewModel
    {
        #region Attributes
        private string nombre;
        private string correo;
        private string celular;
        private string asunto;
        private string mensaje;
        private string peticion;
        #endregion

        #region Properties


        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string Correo
        {
            get { return this.correo; }
            set { SetValue(ref this.correo, value); }
        }

        public string Celular
        {
            get { return this.celular; }
            set { SetValue(ref this.celular, value); }
        }

        public string Asunto
        {
            get { return this.asunto; }
            set { SetValue(ref this.asunto, value); }
        }

        public string Mensaje
        {
            get { return this.mensaje; }
            set { SetValue(ref this.mensaje, value); }
        }

        public string Peticion
        {
            get { return this.peticion; }
            set { SetValue(ref this.peticion, value); }
        }

        #endregion

        #region Commands
        public ICommand SendPetitionCommand
        {
            get
            {
                return new RelayCommand(SendPetitionAsync);
            }
        }

        public ICommand SendContactCommand
        {
            get
            {
                return new RelayCommand(SendContact);
            }
        }

        void SendPetitionAsync()
        {
            using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
            {
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential("vesapp@outlook.com", "espiritusanto2020");
                MailMessage mensaje = new MailMessage("vesapp@outlook.com", "vesapp@outlook.com", "Petición de " + Nombre, Peticion);
                cliente.Send(mensaje);
            }
            var toastConfig = new ToastConfig("Enviado");
            toastConfig.SetDuration(4000);
            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(33, 150, 243));

            UserDialogs.Instance.Toast(toastConfig);
        }

        void SendContact()
        {
            using (SmtpClient cliente = new SmtpClient("smtp.live.com", 25))
            {
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential("vesapp@outlook.com", "espiritusanto2020");
                MailMessage mensaje = new MailMessage("vesapp@outlook.com", "vesapp@outlook.com", "Contacto de " + Nombre, "Correo: " + Correo + "\n Celular: " + Celular + "\n Asunto: " + Asunto + "\n Mensaje: " + Mensaje);
                cliente.Send(mensaje);
            }
            var toastConfig = new ToastConfig("Enviado");
            toastConfig.SetDuration(4000);
            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(33, 150, 243));

            UserDialogs.Instance.Toast(toastConfig);
        }
        #endregion
    }
}
