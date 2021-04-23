using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Authentications;
using Xamarin.Forms;

namespace QuizEducation.Views.Authentications
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new SignUpViewModel(pageHelper);
        }
        public SignUpViewModel ViewModel
        {
            get => BindingContext as SignUpViewModel;
            set => BindingContext = value;
        }
    }
}
