﻿using System;
using System.Collections.Generic;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Quiz;
using Xamarin.Forms;

namespace QuizEducation.Views.Quizzes
{
    public partial class AddQuestionPage : ContentPage
    {
        public AddQuestionPage()
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new AddQuestionViewModel(pageHelper);
        }
        public AddQuestionViewModel ViewModel
        {
            get => BindingContext as AddQuestionViewModel;
            set => BindingContext = value;
        }
    }
}
