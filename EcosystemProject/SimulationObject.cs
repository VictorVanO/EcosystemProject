using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        private Simulation simulation;
        public SimulationObject(Type classe,Color color, double x, double y, double health, double energy, string gender, Simulation simulation) : base(classe,color, x, y, health, energy, gender)
        { 
            this.simulation = simulation;
        }

        public Simulation get_simulation() { return simulation; }

        abstract public void Update();
    }
}

