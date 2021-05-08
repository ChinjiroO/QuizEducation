using System;
using System.Collections.Generic;
using System.Linq;
using QuizEducation.ViewModels;
using QuizEducation.ViewModels.Dashboard;
using QuizEducation.ViewModels.Quiz;
using QuizEducation.Views.Quizzes;
using Xamarin.Forms;

namespace QuizEducation.Views.Dashboard
{
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage()
        {
            InitializeComponent();
            var pageHelper = new PageHelper();

            ViewModel = new ActivityViewModel(pageHelper);
        }
        public ActivityViewModel ViewModel
        {
            get => BindingContext as ActivityViewModel;
            set => BindingContext = value;
        }
    

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;
            if (!(e.CurrentSelection.First() is Models.Quizzes item))
                return;

            var pageHelper = new PageHelper();

            await pageHelper.PushAsync(new QuizEditorPage(new QuizEditorViewModel(pageHelper)));

            // Manually deselect item.
            QuizzesListView.SelectedItem = null;
        }
    }
}
