using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        Simulation simulation;
        float radius;
        string ready = "No";

        public SimulationObject(Type classe,Color color, double x, double y, double health, double energy, string gender, Simulation simulation,float radius,string ready) : base(classe,color, x, y, health, energy, gender)
        { 
            this.simulation = simulation;
            this.radius = radius;
            this.ready = ready;
        }

        public Simulation get_simulation() { return simulation; }
        public float Radius { get { return radius; } set { radius = value; } }
        public string Ready { get { return this.ready; } set { this.ready = value; } }

        abstract public void Update();
        public abstract void Draw(ICanvas canvas);

    }
}

