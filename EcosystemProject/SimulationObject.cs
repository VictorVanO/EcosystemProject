using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        private Simulation simulation;
        float radius;
        string Ready = "No";

        public SimulationObject(Type classe,Color color, double x, double y, double health, double energy, string gender, Simulation simulation,float radius,string Ready) : base(classe,color, x, y, health, energy, gender)
        { 
            this.simulation = simulation;
            this.radius = radius;
            this.Ready = Ready;
        }

        public Simulation get_simulation() { return simulation; }
        public float Radius { get { return radius; } set { radius = value; } }
        public string ready { get { return this.Ready; } set { this.Ready = value; } }

        abstract public void Update();
        
    }
}

