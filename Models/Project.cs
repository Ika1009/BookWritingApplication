using SQLite;
using System;
using System.IO;
using Microsoft.Maui.Storage; // Add this if using MAUI and need access to FileSystem

namespace BookWritingApplication.Models
{
    [Table("projects")]
    public class Project
    {
        [PrimaryKey]
        public string ProjectID { get; set; }

        [NotNull, MaxLength(255)]
        public string ProjectName { get; set; }

        [NotNull, MaxLength(255)]
        public string AuthorName { get; set; }

        [NotNull, MaxLength(100)]
        public string Genre { get; set; }

        [NotNull]
        public int Year { get; set; }

        [NotNull, MaxLength(255)]
        public string Publication { get; set; }

        [NotNull, MaxLength(255)]
        public string Image { get; set; }

        // Settings properties directly included
        [NotNull, MaxLength(255)]
        public string FontSize { get; set; } = "Medium";

        [NotNull, MaxLength(255)]
        public string BackgroundColor { get; set; } = "#FFFFFF";

        [NotNull, MaxLength(255)]
        public string TextColor { get; set; } = "#000000";

        [NotNull, MaxLength(255)]
        public string Font { get; set; } = "Default";

        [NotNull]
        public bool DarkMode { get; set; } = false;

        // Path to the file that stores the content of this project
        [NotNull, MaxLength(255)]
        public string ContentFilePath { get; set; }

        // Path to the file that stores research content for this project
        [NotNull, MaxLength(255)]
        public string ResearchFilePath { get; set; }

        // Path to the file that stores world-building content for this project
        [NotNull, MaxLength(255)]
        public string WorldBuildingFilePath { get; set; }

        // Default constructor calls the parameterized constructor with default values
        public Project() : this(string.Empty, string.Empty, string.Empty, DateTime.Now.Year, string.Empty, string.Empty)
        {
        }

        // Constructor with parameters for convenience
        public Project(string projectName, string authorName, string genre, int year, string publication, string image)
        {
            ProjectID = Guid.NewGuid().ToString();
            ProjectName = projectName;
            AuthorName = authorName;
            Genre = genre;
            Year = year;
            Publication = publication;
            Image = image;

            // Automatically generate file paths for content, research, and world-building
            ContentFilePath = Path.Combine(FileSystem.AppDataDirectory, $"{ProjectID}_Content.txt");
            ResearchFilePath = Path.Combine(FileSystem.AppDataDirectory, $"{ProjectID}_Research.txt");
            WorldBuildingFilePath = Path.Combine(FileSystem.AppDataDirectory, $"{ProjectID}_WorldBuilding.txt");

            // Create the files to ensure paths are valid
            File.Create(ContentFilePath).Dispose();
            File.Create(ResearchFilePath).Dispose();
            File.Create(WorldBuildingFilePath).Dispose();
        }
        // Constructor with parameters for convenience
        public Project(string projectName, string authorName, string genre)
        {
            ProjectID = Guid.NewGuid().ToString();
            ProjectName = projectName;
            AuthorName = authorName;
            Genre = genre;
            Year = DateTime.Now.Year;
            Publication = "";
            Image = "";

            // Automatically generate file paths for content, research, and world-building
            ContentFilePath = Path.Combine(FileSystem.AppDataDirectory, $"{ProjectID}_Content.txt");
            ResearchFilePath = Path.Combine(FileSystem.AppDataDirectory, $"{ProjectID}_Research.txt");
            WorldBuildingFilePath = Path.Combine(FileSystem.AppDataDirectory, $"{ProjectID}_WorldBuilding.txt");

            // Create the files to ensure paths are valid
            File.Create(ContentFilePath).Dispose();
            File.Create(ResearchFilePath).Dispose();
            File.Create(WorldBuildingFilePath).Dispose();
        }
    }
}
