using SQLite;

namespace BookWritingApplication.Models
{
    [Table("projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int ProjectID { get; set; }

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
        public Project() : this(string.Empty, string.Empty, string.Empty, DateTime.Now.Year, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        // Constructor with parameters for convenience
        public Project(string projectName, string authorName, string genre, int year, string publication, string image, string contentFilePath, string researchFilePath, string worldBuildingFilePath)
        {
            ProjectName = projectName;
            AuthorName = authorName;
            Genre = genre;
            Year = year;
            Publication = publication;
            Image = image;
            ContentFilePath = contentFilePath;
            ResearchFilePath = researchFilePath;
            WorldBuildingFilePath = worldBuildingFilePath;
        }
    }
}
