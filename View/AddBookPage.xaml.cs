using BookWritingApplication.Models;
using BookWritingApplication;
using Microsoft.Maui.Controls;
using System;

namespace BookWritingApplication.View
{
    public partial class AddBookPage : ContentPage
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(".."); // Navigates back in the navigation stack
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Create a new Project instance
                var project = new Project
                {
                    ProjectName = ProjectNameEntry.Text,
                    AuthorName = AuthorNameEntry.Text,
                    Genre = GenreEntry.Text,
                    Year = YearPicker.Date.Year,
                    Publication = PublicationEntry.Text,
                    Image = "", // For now, leaving this empty. Implement image selection logic accordingly.
                };

                // Save the project using DatabaseService
                var result = await DatabaseService.AddProjectAsync(project);

                if (result > 0)
                {
                    // Successfully saved
                    await DisplayAlert("Success", "Project successfully added.", "OK");
                    await Shell.Current.GoToAsync(".."); // Optionally, navigate back or to another page
                }
                else
                {
                    // Failed to save
                    await DisplayAlert("Error", "Failed to add the project.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the save operation
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        // Placeholder for the image selection logic
        private void OnSelectImageButtonClicked(object sender, EventArgs e)
        {
            // Implement the logic to select an image and set the Image property of the Project instance accordingly
            // You might use a FilePicker or any other method as per your application requirements
        }
    }
}
