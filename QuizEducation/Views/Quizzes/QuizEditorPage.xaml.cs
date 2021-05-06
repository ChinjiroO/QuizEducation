using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Quiz;
using Xamarin.Forms;

namespace QuizEducation.Views.Quizzes
{
    public partial class QuizEditorPage : ContentPage
    {
        public QuizEditorPage()
        {            
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new QuizEditorViewModel(pageHelper);
        }
        public QuizEditorViewModel ViewModel
        {
            get => BindingContext as QuizEditorViewModel;
            set => BindingContext = value;
        }
    }
}
