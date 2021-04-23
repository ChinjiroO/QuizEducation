using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Authentications;
using Xamarin.Forms;

namespace QuizEducation.Views.Authentications
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        { 
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new SignInViewModel(pageHelper);
        }
        public SignInViewModel ViewModel
        {
            get => BindingContext as SignInViewModel;
            set => BindingContext = value;
        }
    }
}
