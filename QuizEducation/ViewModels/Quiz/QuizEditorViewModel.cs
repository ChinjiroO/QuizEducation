using System;
using System.Windows.Input;
using QuizEducation.Helper;
using QuizEducation.Models;
using QuizEducation.Views.Quizzes;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Quiz
{
    public class QuizEditorViewModel : BaseViewModel
    {
        private IPageHelper _pageHelper;
        private string docId;

        public string DocId
        {
            get => docId;
            set => SetProperty(ref docId, value);
        }

        public QuizEditorViewModel(IPageHelper pageHelper, String idRef = null)
        {
            _pageHelper = pageHelper;
            docId = idRef;
            PushToHomeCommand = new Command(PushToHome);
            AddQuestionCommand = new Command(AddQuestion);
        }

        //---------------------------Methods---------------------------
        public ICommand PushToHomeCommand { get; }
        private void PushToHome()
        {
            Application.Current.MainPage = new AppShell();
        }

        public ICommand AddQuestionCommand { get; }
        private async void AddQuestion()
        {
            await _pageHelper.PushAsync(new AddQuestionPage());
        }
    }
}
