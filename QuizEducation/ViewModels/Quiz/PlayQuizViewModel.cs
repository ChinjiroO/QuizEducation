using System;
using System.Windows.Input;
using QuizEducation.Helper;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Quiz
{
    public class PlayQuizViewModel : BaseViewModel
    {
        public ICommand PopAsyncCommand { get; }


        // Constructor
        public PlayQuizViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
            PopAsyncCommand = new Command(PopAsync);
        }

        //Variable
        private IPageHelper _pageHelper;

        private async void PopAsync()
        {
            await _pageHelper.PopAsync();
        }
    }
}
