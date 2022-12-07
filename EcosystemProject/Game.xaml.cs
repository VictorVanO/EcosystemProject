namespace EcosystemProject;

public partial class Game : ContentPage
{
    IDispatcherTimer timer;
    Simulation Simulation;
    bool isRunning = true;
    public Game()
	{
		InitializeComponent();

        Simulation = Resources["Simulation"] as Simulation;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(10);
        timer.Tick += this.OnTimeEvent;
        timer.Start();
    }
    private void OnTimeEvent(object source, EventArgs e)
    {
        Simulation.Update();
        if(graphics != null)
        {
            graphics.Invalidate();
        }
    }
    private void PauseClicked(object sender, EventArgs e)
    {
        isRunning = !isRunning;
        if (isRunning)
        {
            timer.Start();
            PauseBtn.Text = "Pause";
        } 
        else
        {
            timer.Stop();
            PauseBtn.Text = "Start";
        }
    }
}