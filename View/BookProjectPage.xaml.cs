using Microsoft.Maui.Controls;
using System;

namespace BookWritingApplication.View
{
    [QueryProperty(nameof(ProjectId), "projectId")]
    public partial class BookProjectPage : ContentPage
    {
        private string projectId;

        public string ProjectId
        {
            get => projectId;
            set
            {
                projectId = Uri.UnescapeDataString(value ?? string.Empty);
                LoadProject(projectId); // Load your project details here
            }
        }

        public BookProjectPage()
        {
            InitializeComponent();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigation back logic remains the same
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.GoToAsync(".."); // Navigates back in the navigation stack
            }
        }

        private void LoadProject(string projectId)
        {
            // Implement the logic to load project details based on projectId
        }

        // OnNavigatedTo override might not be necessary if you're using QueryProperty
    }
}
