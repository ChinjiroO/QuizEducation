using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Quiz;
using Xamarin.Forms;

namespace QuizEducation.Views.Quizzes
{
    public partial class AddQuizPage : ContentPage
    {
        public AddQuizPage()
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new AddQuizViewModel(pageHelper);
        }
        public AddQuizViewModel ViewModel
        {
            get => BindingContext as AddQuizViewModel;
            set => BindingContext = value;
        }
    }
}
