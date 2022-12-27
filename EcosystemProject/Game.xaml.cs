using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject;

public partial class Game : ContentPage
{
    IDispatcherTimer timer;
    Simulation simulation;
    bool isRunning = true;

    int gameSpeed = 10;

    Random random = new Random();
    string[] genders = { "M", "F" };
    public Game()
	{
		InitializeComponent();

        simulation = Resources["Simulation"] as Simulation;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
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
            PauseBtn.Text = "PAUSE";
        } 
        else
        {
            timer.Stop();
            PauseBtn.Text = "START";
        }
    }
    private void SpeedClicked(object sender, EventArgs e)
    {
        if (gameSpeed == 10)
        {
            SpeedBtn.Text = "x2";
            gameSpeed = 5;
        }
        else if (gameSpeed == 5)
        {
            SpeedBtn.Text = "x10";
            gameSpeed = 1;
        }
        else if (gameSpeed == 1)
        {
            SpeedBtn.Text = "x1";
            gameSpeed = 10;
        }
    }

    private void AddAnimalClicked(object sender, EventArgs e)
    {
        simulation.Add(new Animal(random.Next(100, 1400), random.Next(100, 550), 10, 10, 0, 0, genders[random.Next(genders.Length)], simulation));
    }
    private void AddPlantClicked(object sender, EventArgs e)
    {
        simulation.Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 0, 0, simulation));
    }
}