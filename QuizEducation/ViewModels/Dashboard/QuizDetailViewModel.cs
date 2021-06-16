using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Plugin.CloudFirestore;
using QuizEducation.Helper;
using QuizEducation.Models;
using Xamarin.Forms;

namespace QuizEducation.ViewModels.Dashboard
{
    public class QuizDetailViewModel : BaseViewModel
    {
        private IPageHelper _pageHelper;
        private string docId;
        private string imageUrl;
        private string title;
        private string description;
        private string createdBy;

        public string ImageUrl
        {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string CreatedBy
        {
            get => createdBy;
            set => SetProperty(ref createdBy, value);
        }

        public string DocId
        {
            get => docId;
            set => SetProperty(ref docId, value);
        }
        public QuizDetailViewModel(IPageHelper pageHelper, String docIdRef = null)
        {
            _pageHelper = pageHelper;

            DocId = docIdRef;

            PopAsyncCommand = new Command(Pop);
            GetQuizzes();
        }

        public ICommand PopAsyncCommand { get; }
        private async void Pop()
        {
            await _pageHelper.PopAsync();
        }

        private async void GetQuizzes()
        {
            var collection = await CrossCloudFirestore.Current.Instance
                                                    .Collection("Quizzes")
                                                    .Document(DocId)
                                                    .GetAsync();
            var quizModel = collection.ToObject<Quizzes>();
            ImageUrl = quizModel.imageUrl;
            Title = quizModel.title;
            Description = quizModel.description;
            CreatedBy = quizModel.createdBy;
        }
    }    
}
