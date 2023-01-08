namespace EcosystemProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		//create an AppShell
		MainPage = new AppShell();
	}
}
