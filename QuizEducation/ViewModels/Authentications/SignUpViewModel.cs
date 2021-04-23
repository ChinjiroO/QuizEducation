using System;
using System.Windows.Input;
using Plugin.FirebaseAuth;
using Plugin.CloudFirestore;
using QuizEducation.Helper;
using Xamarin.Forms;
using QuizEducation.Models;

namespace QuizEducation.ViewModels.Authentications
{
    public class SignUpViewModel : BaseViewModel
    {

        //Variable
        private string email;
        private string password;
        private string verifyPassword;
        private string username;
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
        public string VerifyPassword
        {
            get => verifyPassword;
            set => SetProperty(ref verifyPassword, value);
        }
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        //Command
        public ICommand PopCommand { get; }
        public ICommand SignUpCommand { get; }

        //Method
        public SignUpViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;

            PopCommand = new Command(Pop);
            SignUpCommand = new Command(SignUp);
        }
        private async void Pop()
        {
            await _pageHelper.PopAsync();
        }
        private async void SignUp()
        {
            try
            {
                var firebaseAuth = CrossFirebaseAuth.Current.Instance;

                if (Password == VerifyPassword && Username != null)
                {
                    var result = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(Email, Password);
                    await CrossCloudFirestore.Current.Instance
                                                     .Collection("Users")
                                                     .Document(firebaseAuth.CurrentUser.Uid)
                                                     .SetAsync(new Users {
                                                         email = Email,
                                                         name = Username,
                                                     });

                    Application.Current.MainPage = new AppShell();
                }
                else await Application.Current.MainPage.DisplayAlert("Error","Password wrong!","OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await Application.Current.MainPage.DisplayAlert("SignUp", "An error occurs", "OK");
            }
        }
    }
}
