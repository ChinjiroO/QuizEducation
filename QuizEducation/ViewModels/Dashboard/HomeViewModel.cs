using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.CloudFirestore;
using Plugin.FirebaseAuth;
using QuizEducation.Helper;
using QuizEducation.Models;
using QuizEducation.Views.Authentications;
using QuizEducation.Views.Quizzes;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Dashboard
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
            //Load();
            GetRecommendQuizList();
            GetCurrentUsername();
            PushToQuizCommand = new Command(PushToQuiz);
        }

        //Variable
        private IPageHelper _pageHelper;
        private string username;

        //Set property
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        //Command
        public ICommand PushToQuizCommand { get; }

        //Method
        private async void PushToQuiz()
        {
            await _pageHelper.PushAsync(new AddQuizPage());
        }
        private async void GetCurrentUsername()
        {
            try
            {
                var currentUser = CrossFirebaseAuth.Current.Instance.CurrentUser.Uid;

                var document = await CrossCloudFirestore.Current.Instance
                                                 .Collection("Users")
                                                 .Document(currentUser)
                                                 .GetAsync();

                var userModel = document.ToObject<Users>();
                Username = userModel.name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Task<IEnumerable<Quizzes>> GetQuiz { get => GetRecommendQuizList(); }
        private async Task<IEnumerable<Quizzes>> GetRecommendQuizList()
        {
            var group = await CrossCloudFirestore.Current.Instance
                                                 .Collection("Quizzes")
                                                 .GetAsync();                                                 
            var quizModel = group.ToObjects<Quizzes>();
            return quizModel ;
        }

        //Test binding models
        public ObservableCollection<Quizzes> QuizItems { get => Load(); }

        public ObservableCollection<Quizzes> Load()
        {
            return new ObservableCollection<Quizzes>(new[]
            {
                new Quizzes
                {
                    title="Lorem ipsum",
                    imageUrl=$"https://images.unsplash.com/photo-1584714268709-c3dd9c92b378?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=799&q=80",
                    description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                    createdBy="chin1"
                },
                new Quizzes
                {
                    imageUrl="https://images.unsplash.com/photo-1517404215738-15263e9f9178?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80",
                    title="consectetur adipiscing",
                    description="Consequat ac felis donec et odio pellentesque.",
                    createdBy="chin2"
                },
                new Quizzes
                {
                    imageUrl="https://aka.ms/campus.jpg",
                    title="tempor incididunt",
                    description="Eget velit aliquet sagittis id consectetur.",
                    createdBy="chin3"
                }
            });
        }
    }
}
