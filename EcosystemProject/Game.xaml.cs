namespace EcosystemProject;

public partial class Game : ContentPage
{
    IDispatcherTimer timer;
    Simulation Simulation;
    public Game()
	{
		InitializeComponent();

        Simulation = Resources["Simulation"] as Simulation;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(20);
        timer.Tick += this.OnTimeEvent;
        timer.Start();
    }
    private void OnTimeEvent(object source, EventArgs e)
    {
        Simulation.Update();
        graphics.Invalidate();
    }
    private async void PauseClicked(object sender, EventArgs e)
    {

    }
}