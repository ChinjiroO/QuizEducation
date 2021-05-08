using System;
using System.Collections.Generic;
using System.Linq;
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

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;
            if (!(e.CurrentSelection.First() is Models.Quizzes item))
                return;

            var pageHelper = new PageHelper();

            await pageHelper.PushAsync(new QuizDetailPage(new QuizDetailViewModel(pageHelper, item)));

            // Manually deselect item.
            QuizzesListView.SelectedItem = null;
        }
    }
}
