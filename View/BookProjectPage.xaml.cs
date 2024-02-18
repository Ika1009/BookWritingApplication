using BookWritingApplication.Models;
using Microsoft.Maui.Controls;
using System;

namespace BookWritingApplication.View
{
    [QueryProperty(nameof(ProjectId), "projectId")]
    public partial class BookProjectPage : ContentPage
    {
        private string projectId;
        private Project project;

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

        private async void LoadProject(string projectId)
        {
            try
            {
                // Retrieve project details based on projectId
                var projecttemp = await DatabaseService.GetProjectByIdAsync(projectId);

                if (projecttemp != null)
                {
                    this.project = projecttemp;
                }
                else
                {
                    // Handle the case where project is not found
                    await DisplayAlert("Error", "Project not found", "OK");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                await DisplayAlert("Error", $"Error loading project: {ex.Message}", "OK");
            }
        }

        // OnNavigatedTo override might not be necessary if you're using QueryProperty
    }
}
