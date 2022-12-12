using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject;

public partial class Game : ContentPage
{
    IDispatcherTimer timer;
    Simulation simulation;
    bool isRunning = true;

    Random random = new Random();
    public Game()
	{
		InitializeComponent();

        simulation = Resources["Simulation"] as Simulation;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(10);
        timer.Tick += this.OnTimeEvent;
        timer.Start();
    }
    private void OnTimeEvent(object source, EventArgs e)
    {
        simulation.Update();
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

    private void AddClicked(object sender, EventArgs e)
    {
        simulation.objects.Add(new Animal(random.Next(100, 1400), random.Next(100, 550), 10, 10, 0, 0, 0, 0, simulation));
    }
}