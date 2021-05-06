using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Dashboard;
using Xamarin.Forms;

namespace QuizEducation.Views.Dashboard
{
    public partial class QuizDetailPage : ContentPage
    {
        public QuizDetailPage(QuizDetailViewModel viewModels)
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new QuizDetailViewModel(pageHelper);
            ViewModel = viewModels;
        }
        public QuizDetailViewModel ViewModel
        {
            get => BindingContext as QuizDetailViewModel;
            set => BindingContext = value;
        }    
    }
}
