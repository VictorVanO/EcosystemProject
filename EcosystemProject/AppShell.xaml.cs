namespace EcosystemProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        //link the AppShell to two routes: MainMenu and Game
        Routing.RegisterRoute(nameof(MainMenu), typeof(MainMenu));
        Routing.RegisterRoute(nameof(Game), typeof(Game));
    }
}
