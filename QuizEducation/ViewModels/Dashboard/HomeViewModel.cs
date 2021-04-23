using System;
using System.Windows.Input;
using Plugin.FirebaseAuth;
using QuizEducation.Helper;
using QuizEducation.Views.Authentications;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Dashboard
{
    public class HomeViewModel : BaseViewModel
    {
        //Variable
        private IPageHelper _pageHelper;

        //Set property



        //Command
        public ICommand PopCommand { get; }
        public ICommand SignOutCommand { get; }

        //Method
        public HomeViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;

            PopCommand = new Command(Pop);
            SignOutCommand = new Command(SignOut);
        }
        private async void Pop()
        {
            await _pageHelper.PopAsync();
        }
        private void SignOut()
        {
            CrossFirebaseAuth.Current.Instance.SignOut();
            Application.Current.MainPage = new SignInPage();
        }
    }
}
