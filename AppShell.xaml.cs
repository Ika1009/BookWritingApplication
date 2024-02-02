using BookWritingApplication.View;

namespace BookWritingApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register the main route
            Routing.RegisterRoute("mainPage", typeof(MainPage));

            // Register sub-routes of mainPage
            Routing.RegisterRoute("mainPage/addBookPage", typeof(AddBookPage));
            Routing.RegisterRoute("mainPage/writingPromptsPage", typeof(WritingPromptsPage));
            Routing.RegisterRoute("mainPage/writersJournalPage", typeof(WritersJournalPage));
            Routing.RegisterRoute("mainPage/dictionaryPage", typeof(DictionaryPage));
            Routing.RegisterRoute("mainPage/settingsPage", typeof(SettingsPage));

        }
    }
}
