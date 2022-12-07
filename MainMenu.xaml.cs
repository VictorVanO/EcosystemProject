namespace EcosystemProject;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
    }
    private async void OnStartClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Game)); // Go to 'Game' view
    }
    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Game));
    }
    private void OnQuitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit(); // Close the app
    }
}