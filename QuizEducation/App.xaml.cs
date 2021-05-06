using System;
using Plugin.FirebaseAuth;
using QuizEducation.Views.Authentications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizEducation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Sharpnado.MaterialFrame.Initializer.Initialize(loggerEnable: false, debugLogEnable: false);

            if (!IsSignIn())
            {
                MainPage = new SignInPage();
            }
            else
                MainPage = new AppShell();
        }
        public bool IsSignIn()
        {
            var currentUser = CrossFirebaseAuth.Current.Instance.CurrentUser;
            return currentUser != null;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
