using System;
using System.Threading.Tasks;
using QuizEducation.Helper;
using Xamarin.Forms;

namespace QuizEducation.ViewModels
{
    public class PageHelper : IPageHelper
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushModalAsync(page);
        }
        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
