using System;
using System.Windows.Input;
using QuizEducation.Helper;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Quiz
{
    public class AddQuizViewModel : BaseViewModel
    {
        public AddQuizViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;

            PopAsyncCommand = new Command(Pop);
        }

        //---------------------------Variables---------------------------
        private IPageHelper _pageHelper;

        //---------------------------Commands---------------------------
        public ICommand PopAsyncCommand { get; }

        //---------------------------Methods---------------------------
        private async void Pop()
        {
            await _pageHelper.PopAsync();
        }
    }
}
