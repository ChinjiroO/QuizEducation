﻿using System;
using System.Windows.Input;
using QuizEducation.Helper;
using Xamarin.Forms;
using Plugin.CloudFirestore;
using Plugin.FirebaseAuth;
using QuizEducation.Models;
using QuizEducation.Views.Quizzes;

namespace QuizEducation.ViewModels.Quiz
{
    public class AddQuizViewModel : BaseViewModel
    {
        public AddQuizViewModel(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;

            PopAsyncCommand = new Command(Pop);
            SubmitCommand = new Command(CreateQuiz);
        }

        //---------------------------Variables---------------------------
        private IPageHelper _pageHelper;
        private string title;
        private string imageUrl;
        private string description;

        //---------------------------Commands---------------------------
        public ICommand PopAsyncCommand { get; }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string ImageUrl
        {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public ICommand SubmitCommand { get; }

        //---------------------------Methods---------------------------
        private async void Pop()
        {
            await _pageHelper.PopAsync();
        }
        private async void CreateQuiz()
        {
            try
            {
                if (Title != null)
                {
                    var uid = CrossFirebaseAuth.Current.Instance.CurrentUser.Uid;

                    var getUsers = await CrossCloudFirestore.Current.Instance
                                                              .Collection("Users")
                                                              .Document(uid)
                                                              .GetAsync();
                    var usersModel = getUsers.ToObject<Users>();

                    await CrossCloudFirestore.Current
                                            .Instance
                                            .Collection("Quizzes")
                                            .AddAsync(new Quizzes
                                            {
                                                title = Title,
                                                imageUrl = ImageUrl,
                                                description = Description,
                                                createdBy = usersModel.name
                                            });
                    Application.Current.MainPage = new QuizEditorPage();
                }
                else 
                {
                    await Application.Current.MainPage.DisplayAlert("Add quiz", "Please ... title of this quiz.", "OK");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
