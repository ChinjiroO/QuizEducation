using System;
using System.Windows.Input;
using Plugin.CloudFirestore;
using Plugin.FirebaseAuth;
using QuizEducation.Helper;
using QuizEducation.Models;
using QuizEducation.Views.Authentications;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Dashboard
{
    public class SettingViewModel : BaseViewModel
    {
        public SettingViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
            SignOutCommand = new Command(SignOut);
            GetCurrentUsername();
        }
        //Variable
        private IPageHelper _pageHelper;
        private string username;
        private string updUsername;

        //Set property
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public string UpdUsername
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        //Command
        public ICommand SignOutCommand { get; }

        //Method
        private async void GetCurrentUsername()
        {
            try
            {
                var currentUser = CrossFirebaseAuth.Current.Instance.CurrentUser.Uid;

                var document = await CrossCloudFirestore.Current.Instance
                                                 .Collection("Users")
                                                 .Document(currentUser)
                                                 .GetAsync();

                var userModel = document.ToObject<Users>();
                Username = userModel.name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void UpdateUsername()
        {

        }
        private void SignOut()
        {
            CrossFirebaseAuth.Current.Instance.SignOut();
            Application.Current.MainPage = new SignInPage();
        }
    }
}
