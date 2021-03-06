using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Quiz;
using Xamarin.Forms;

namespace QuizEducation.Views.Quizzes
{
    public partial class PlayQuizPage : ContentPage
    {
        public PlayQuizPage()
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new PlayQuizViewModel(pageHelper);
        }
        public PlayQuizViewModel ViewModel
        {
            get => BindingContext as PlayQuizViewModel;
            set => BindingContext = value;
        }
           
    }
}
