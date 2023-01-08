
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject;

public partial class Game : ContentPage
{
    IDispatcherTimer timer;
    Simulation simulation;
    bool isRunning = true;
    Random random = new Random();
    string[] genders = { "M", "F" };
    Type[] Classes = { typeof(Carnivorous), typeof(Herbivorous) };
    int Hitbox = 1;
    SimulationObject Item;
    int Count;
    int gameSpeed = 1;
public Game()
	{
        InitializeComponent();
        //creates the variable Simulation
        simulation = Resources["Simulation"] as Simulation;
        //create a timer
        timer = Dispatcher.CreateTimer();
        //Fix the interval of the timer at 1 milliseconds
        timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
        //each 1 milliseconds launch the OnTimeEvent method
        timer.Tick += this.OnTimeEvent;
        //start the simulation
        timer.Start();   
    }
    private void OnTimeEvent(object source, EventArgs e)
    {
        //Update the simulation
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
    private void CountClicked(object sender, EventArgs e)
    {
       
        foreach (SimulationObject item in simulation.Objects)
        {
            Item = item;
            if(item.GetType() == typeof(Plant)| item.GetType() == typeof(Animal) )
            {
                Count += 1;
            }
            
        }
        CountBtn.Text = "living beings: "+Count.ToString();
        Count = 0;
        
    }

    private void AddAnimalClicked(object sender, EventArgs e)
    {
        foreach (SimulationObject item in simulation.Objects)
        {
            Item = item;
        }
        simulation.Add(new Animal(Classes[random.Next(Classes.Length)],Colors.Red,random.Next(100, 1400), random.Next(100, 550), 10, 10, 100, 30, genders[random.Next(genders.Length)],"No", simulation, Item.Radius));
    }
    private void AddPlantClicked(object sender, EventArgs e)
    {
        foreach (SimulationObject item in simulation.Objects)
        {
            Item = item;
        }
        simulation.Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 160, 50, simulation,Item.Radius ));
    }
    private void Showhitboxes(object sender, EventArgs e)
    {
        if (Hitbox == 1)
        { 
            foreach (SimulationObject item in simulation.Objects)
            {
                item.Radius = 1;
            }
            Showbtn.Text = "Hide Hitbox";
            Hitbox = 0;
        }
        else if (Hitbox == 0)
        {
            foreach (SimulationObject item in simulation.Objects)
            {
                item.Radius = 0;
            }
            Showbtn.Text = "Show Hitbox";
            Hitbox = 1;
        }
    }
}