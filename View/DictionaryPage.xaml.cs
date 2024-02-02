namespace BookWritingApplication.View;

public partial class DictionaryPage : ContentPage
{
	public DictionaryPage()
	{
		InitializeComponent();
	}
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Check if the current page can navigate back
        if (Shell.Current.Navigation.NavigationStack.Count > 1)
        {
            await Shell.Current.GoToAsync(".."); // Navigates back in the navigation stack
        }
    }
}