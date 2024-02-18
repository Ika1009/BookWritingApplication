using CommunityToolkit.Maui.Views;
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
            var popup = new AddBookPopup();
            popup.BookAdded += async (sender, e) =>
            {
                // Use the provided project ID to navigate to the correct page
                await Shell.Current.GoToAsync($"//mainPage/bookProjectPage?projectId={e.ProjectId}");
            };
            await this.ShowPopupAsync(popup);
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
