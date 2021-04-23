using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Dashboard;
using Xamarin.Forms;

namespace QuizEducation.Views.Dashboard
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new HomeViewModel(pageHelper);
        }
        public HomeViewModel ViewModel
        {
            get => BindingContext as HomeViewModel;
            set => BindingContext = value;
        }
    }
}
