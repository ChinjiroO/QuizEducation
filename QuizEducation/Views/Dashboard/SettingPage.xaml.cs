using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Dashboard;
using Xamarin.Forms;

namespace QuizEducation.Views.Dashboard
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new SettingViewModel(pageHelper);
        }
        public SettingViewModel ViewModel
        {
            get => BindingContext as SettingViewModel;
            set => BindingContext = value;
        }
    }
}
