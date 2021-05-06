using System;
using System.Collections.Generic;
using System.Windows.Input;
using Plugin.CloudFirestore;
using Plugin.FirebaseAuth;
using QuizEducation.Helper;
using QuizEducation.Models;
using QuizEducation.Views.Quizzes;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using QuizEducation.Views.Dashboard;

namespace QuizEducation.ViewModels.Dashboard
{
    public class HomeViewModel : BaseViewModel
    {
        // Constructor
        public HomeViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
            GetCurrentUsername();
            GetAllQuizzes();
            PushToQuizCommand = new Command(PushToQuiz);
            PushViewAllCommand = new Command(PushViewAll);
        }

        //Variable
        private IPageHelper _pageHelper;
        private string username;
        public List<Quizzes> _QuizzesList;

        //Set property
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public List<Quizzes> QuizzesList
        {
            get => _QuizzesList;
            set => SetProperty(ref _QuizzesList, value);
        }

        //Commad
        public ICommand PushToQuizCommand { get; }
        public ICommand PushViewAllCommand { get; }

        //Method
        private async void PushViewAll()
        {
            await Shell.Current.GoToAsync("//ActivityPage");
        }
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
            Console.WriteLine(Username);
        }
        private async void GetAllQuizzes()
        {
            var collection = await CrossCloudFirestore.Current.Instance
                                                    .Collection("Quizzes")
                                                    .GetAsync();
            var quizModel = collection.ToObjects<Quizzes>().Cast<Quizzes>().ToList();
            QuizzesList = quizModel;
        }
        private async void TappedQuiz()
        {
            //await _pageHelper.PushAsync(new QuizDetailPage());
        }
       
    }

}
