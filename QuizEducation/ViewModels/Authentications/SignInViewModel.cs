using System;
using System.Windows.Input;
using Plugin.FirebaseAuth;
using QuizEducation.Helper;
using QuizEducation.Views.Authentications;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Authentications
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;

            PushToSignUpCommand = new Command(PushToSignUp);
            SignInCommand = new Command(SignIn);
        }
        //Variable
        private string email;
        private string password;
        private IPageHelper _pageHelper;

        //Set property
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        //Command
        public ICommand PushToSignUpCommand { get; }
        public ICommand SignInCommand { get; }


        //Method
        private async void PushToSignUp()
        {
            await _pageHelper.PushAsync(new SignUpPage());
        }

        private async void SignIn()
        {
            try
            {
                var firebaseAuth = CrossFirebaseAuth.Current.Instance;
                var result = await firebaseAuth.SignInWithEmailAndPasswordAsync(Email, Password);

                Application.Current.MainPage = new AppShell();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await Application.Current.MainPage.DisplayAlert("SignIn", "An error occurs", "OK");
            }
        }
    }
}
