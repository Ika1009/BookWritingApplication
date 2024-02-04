using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWritingApplication.Models
{
    [SQLite.Table("settings")]
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int SettingsID { get; set; }

        [ForeignKey("projects")]
        public int ProjectID { get; set; }

        [NotNull, MaxLength(255)]
        public string FontSize { get; set; }

        [NotNull, MaxLength(255)]
        public string BackgroundColor { get; set; }

        [NotNull, MaxLength(255)]
        public string TextColor { get; set; }

        [NotNull, MaxLength(255)]
        public string Font { get; set; }

        [NotNull]
        public bool DarkMode { get; set; }

        public Settings()
        {
            FontSize = "Medium";
            BackgroundColor = "#FFFFFF";
            TextColor = "#000000";
            Font = "Default";
            DarkMode = false;
        }

        // Constructor with parameters for flexibility
        public Settings(int projectID, string fontSize, string backgroundColor, string textColor, string font, bool darkMode)
        {
            ProjectID = projectID;
            FontSize = fontSize;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            Font = font;
            DarkMode = darkMode;
        }
    }
}
