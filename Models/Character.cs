using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWritingApplication.Models
{
    [SQLite.Table("characters")]
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int CharacterID { get; set; }

        [ForeignKey("projects")] // Specify the name of the referenced table as a string
        public int ProjectID { get; set; }

        [NotNull, MaxLength(255)]
        public string Name { get; set; }

        [NotNull, MaxLength(100)]
        public string Gender { get; set; }

        [NotNull]
        public int Age { get; set; }

        [NotNull, MaxLength(100)]
        public string Ethnicity { get; set; }

        [NotNull, MaxLength(100)]
        public string DateOfBirth { get; set; }

        [NotNull, MaxLength(100)]
        public string StarSign { get; set; }

        [NotNull, MaxLength(100)]
        public string Personality { get; set; }

        [NotNull, MaxLength(100)]
        public string Height { get; set; }

        [NotNull, MaxLength(100)]
        public string Weight { get; set; }

        [NotNull, MaxLength(100)]
        public string EyeColor { get; set; }

        [NotNull, MaxLength(100)]
        public string HairColor { get; set; }

        // Default constructor
        public Character()
        {
            Name = "Unknown";
            Gender = "Unknown";
            Age = 0;
            Ethnicity = "Unknown";
            DateOfBirth = "Unknown";
            StarSign = "Unknown";
            Personality = "Unknown";
            Height = "Unknown";
            Weight = "Unknown";
            EyeColor = "Unknown";
            HairColor = "Unknown";
        }

        // Constructor with parameters
        public Character(int projectID, string name, string gender, int age, string ethnicity, string dateOfBirth, string starSign, string personality, string height, string weight, string eyeColor, string hairColor)
        {
            ProjectID = projectID;
            Name = name;
            Gender = gender;
            Age = age;
            Ethnicity = ethnicity;
            DateOfBirth = dateOfBirth;
            StarSign = starSign;
            Personality = personality;
            Height = height;
            Weight = weight;
            EyeColor = eyeColor;
            HairColor = hairColor;
        }
    }
}
