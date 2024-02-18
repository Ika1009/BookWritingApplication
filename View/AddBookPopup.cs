using BookWritingApplication.Models;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using System;

namespace BookWritingApplication.View
{
    public class BookAddedEventArgs : EventArgs
    {
        public string ProjectId { get; set; }
    }

    public class AddBookPopup : Popup
    {
        public event EventHandler<BookAddedEventArgs> BookAdded;

        public AddBookPopup()
        {
            // Adjust the size of the popup as needed
            this.Size = new Microsoft.Maui.Graphics.Size(400, 600); // Set width and height accordingly

            var entryName = new Entry { Placeholder = "Name of Book" };
            var entryAuthor = new Entry { Placeholder = "Author Name" };
            var entryGenre = new Entry { Placeholder = "Genre" };

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, args) =>
            {
                // Book saving logic here...
                Project project = new()
                {
                    ProjectName = entryName.Text,
                    AuthorName = entryAuthor.Text,
                    Genre = entryGenre.Text
                };
                await DatabaseService.AddProjectAsync(project);

                // Close the popup
                await CloseAsync();

                // Notify that a book was added
                BookAdded?.Invoke(this, new BookAddedEventArgs { ProjectId = project.ProjectID });
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, args) =>
            {
                // Close the popup
                await CloseAsync();
            };

            Content = new VerticalStackLayout
            {
                Children = { entryName, entryAuthor, entryGenre, saveButton, cancelButton },
                Padding = new Thickness(20)
            };
        }
    }
}
