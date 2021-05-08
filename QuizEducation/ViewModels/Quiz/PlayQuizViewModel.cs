using System;
using QuizEducation.Helper;

namespace QuizEducation.ViewModels.Quiz
{
    public class PlayQuizViewModel : BaseViewModel
    {
        // Constructor
        public PlayQuizViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }

        //Variable
        private IPageHelper _pageHelper;
    }
}
