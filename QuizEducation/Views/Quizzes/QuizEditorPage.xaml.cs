using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Quiz;
using Xamarin.Forms;

namespace QuizEducation.Views.Quizzes
{
    public partial class QuizEditorPage : ContentPage
    {
        public QuizEditorPage(QuizEditorViewModel viewModels)
        {            
            InitializeComponent();

            ViewModel = viewModels;
        }

        public QuizEditorViewModel ViewModel
        {
            get => BindingContext as QuizEditorViewModel;
            set => BindingContext = value;
        }
    }
}
