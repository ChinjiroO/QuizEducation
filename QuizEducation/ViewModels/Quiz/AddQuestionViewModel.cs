using System;
using System.Windows.Input;
using QuizEducation.Helper;
using Xamarin.Forms;
using QuizEducation.Models;
using Plugin.CloudFirestore;

namespace QuizEducation.ViewModels.Quiz
{
    public class AddQuestionViewModel : BaseViewModel
    {
        private IPageHelper _pageHelper;
        private string docId;
        private string question;

        public string DocId
        {
            get => docId;
            set => SetProperty(ref docId, value);
        }
        public string Question
        {
            get => question;
            set => SetProperty(ref question, value);
        }

        public AddQuestionViewModel(IPageHelper pageHelper, String docIdRef = null)
        {
            _pageHelper = pageHelper;

            //Document id from QuizEditor
            DocId = docIdRef;
            PopAsyncCommand = new Command(PopAsync);
            CreateQuestionCommand = new Command(CreateQuestion);
        }

        //---------------------------Methods---------------------------
        public ICommand PopAsyncCommand { get; }
        private async void PopAsync()
        {
            await _pageHelper.PopAsync();
        }

        public ICommand CreateQuestionCommand { get; }
        private async void CreateQuestion()
        {
            try
            {
                if (Question != null)
                {
                    IDocumentReference documentReference = CrossCloudFirestore.Current.Instance
                                                                              .Collection("Quizzes").Document(DocId)
                                                                              .Collection("Question").Document();
                    var currentDocId = documentReference.Id;

                    var item = documentReference.SetAsync(new Questions
                    {
                        questionId = currentDocId,
                        question = Question
                    });
                    PopAsync();
                }
                else await Application.Current.MainPage.DisplayAlert("Question","Empty question","Try again");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
