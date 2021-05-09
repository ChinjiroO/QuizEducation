using System;
using QuizEducation.Helper;
using Plugin.CloudFirestore;
using Plugin.FirebaseAuth;
using QuizEducation.Models;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Dashboard
{
    public class ActivityViewModel : BaseViewModel
    {
        private IPageHelper _pageHelper;
        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public List<Quizzes> _QuizzesList;
        public List<Quizzes> QuizzesList
        {
            get => _QuizzesList;
            set => SetProperty(ref _QuizzesList, value);
        }

        public ActivityViewModel(IPageHelper pageHelper)
        {
            RefreshCommand = new Command(Refresh);

            _pageHelper = pageHelper;
            GetQuizWhereEqualsToUsername();
        }

        //---------------------------Methods---------------------------
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }
        public ICommand RefreshCommand { get; }
        private void Refresh()
        {
            GetQuizWhereEqualsToUsername();
            //Stop refresh
            IsRefreshing = false;
        }

        private async void GetQuizWhereEqualsToUsername()
        {
            var currentUser = CrossFirebaseAuth.Current.Instance.CurrentUser.Uid;
            var document = await CrossCloudFirestore.Current.Instance.Collection("Users")
                                                                     .Document(currentUser)
                                                                     .GetAsync();
            var user = document.ToObject<Users>();
            // get name of current user
            Username = user.name;

            //get data where equals to Username
            var collection = await CrossCloudFirestore.Current.Instance
                                                    .Collection("Quizzes")
                                                    .WhereEqualsTo("createdBy", Username)
                                                    .GetAsync();
            var quizModel = collection.ToObjects<Quizzes>().Cast<Quizzes>().ToList();
            QuizzesList = quizModel;
        }
    }
}
