using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarMaintenance
{

    // [XamlCompilation(XamlCompilationOptions.Compile)]  
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            // BindingContext = new ContentPageViewModel();  
        }

        async void SigUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());


        }

        async void Login_Clicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = UserNameEntry.Text,
                Password = PasswordEntry.Text
            };

            var isVaild = AreCredentialsCorrect(user);
            if (isVaild)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                LoginFaild.Text = "InCorrect Password";
                PasswordEntry.Text = string.Empty;
            }


        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;

        }
    }
}