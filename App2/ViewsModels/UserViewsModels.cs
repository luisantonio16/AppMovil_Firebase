using App2.Models;
using App2.Views;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace App2.ViewsModels
{
    public class UserViewsModels
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Command commandRegister { get; set; }

        public UserViewsModels()
        {
            commandRegister = new Command(Registrar);
        }

        public async void Registrar()

        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Email is not Exist.", "OK");
                return;
            }
            if (string.IsNullOrEmpty(this.Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Password Incorrect.", "OK");
                return;
            }

            string WebApi = "AIzaSyAQ9u_3B5P5PZkBpOUT3UQp7rQOaQKcx10";




            try
            {
                var Provider = new FirebaseAuthProvider(new FirebaseConfig(WebApi));
                var Auth = await Provider.CreateUserWithEmailAndPasswordAsync(Email.ToString(), Contraseña.ToString());
                string getToken = Auth.FirebaseToken;

                await Application.Current.MainPage.DisplayAlert("Welcome", "So Register is Correct.", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", ex.ToString(), "OK");
            }

            


        }
    }
}
