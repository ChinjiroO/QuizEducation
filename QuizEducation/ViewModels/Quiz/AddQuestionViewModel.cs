using System;
using QuizEducation.Helper;

namespace QuizEducation.ViewModels.Quiz
{
    public class AddQuestionViewModel
    {
        public AddQuestionViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }

        //---------------------------Variables---------------------------
        private IPageHelper _pageHelper;
    }
}
