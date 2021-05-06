using System;
using System.Windows.Input;
using QuizEducation.Helper;
using QuizEducation.Views.Quizzes;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Quiz
{
    public class QuizEditorViewModel : BaseViewModel
    {
        public QuizEditorViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
            _pageHelper.PushAsync(new AddQuestionPage());
            PushToHomeCommand = new Command(PushToHome);
        }

        //---------------------------Variables---------------------------
        private IPageHelper _pageHelper;

        //---------------------------Commands---------------------------
        public ICommand PushToHomeCommand { get; }

        //---------------------------Methods---------------------------
        private void PushToHome()
        {
            Application.Current.MainPage = new AppShell();
        }

    }
}
