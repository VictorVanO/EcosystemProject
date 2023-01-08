namespace EcosystemProject;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
    }
    // When clicked on the start button, go to the game window and launch the simulation
    private async void OnStartClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Game)); // Go to 'Game' view
    }
    // When clicked on the Quit button, quit the App
    private void OnQuitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit(); // Close the app
    }
}