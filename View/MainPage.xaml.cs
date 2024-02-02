using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace BookWritingApplication.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddBookClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///mainPage/addBookPage");
        }

        private async void OnWritingPromptsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///mainPage/writingPromptsPage");
        }

        private async void OnWritersJournalClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///mainPage/writersJournalPage");
        }

        private async void OnDictionaryThesaurusClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///mainPage/dictionaryPage");
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///mainPage/settingsPage");
        }
    }
}
