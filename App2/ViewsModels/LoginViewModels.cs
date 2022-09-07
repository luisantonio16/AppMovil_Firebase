using App2.Views;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App2.ViewsModels
{
    public class LoginViewModels
    {

        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Command commandLogin { get; set; }

        public LoginViewModels()
        {
            commandLogin = new Command(LoginUser);
        }

        public async void LoginUser()

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
                var Auth = await Provider.SignInWithEmailAndPasswordAsync(Email.ToString(), Contraseña.ToString());
                var content = await Auth.GetFreshAuthAsync();
                var serial = JsonConvert.SerializeObject(content);

                Preferences.Set("Myfirebase",serial);
           

                await Application.Current.MainPage.DisplayAlert("Welcome", "is Correct.", "OK");
                await Application.Current.MainPage.Navigation.PushModalAsync(new PrincipalPage());

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", ex.ToString(), "OK");
            }




        }
    }
}
