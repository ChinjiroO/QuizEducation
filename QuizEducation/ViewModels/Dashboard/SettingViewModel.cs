using System;
using System.Windows.Input;
using Plugin.FirebaseAuth;
using QuizEducation.Helper;
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
        }
        //Variable
        private IPageHelper _pageHelper;

        //Set property


        //Command
        public ICommand SignOutCommand { get; }

        //Method
        private void SignOut()
        {
            CrossFirebaseAuth.Current.Instance.SignOut();
            Application.Current.MainPage = new SignInPage();
        }
    }
}
