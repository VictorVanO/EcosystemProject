using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        private Simulation simulation;
        public SimulationObject(Color color, double x, double y, double health, double energy, Simulation simulation) : base(color, x, y, health, energy)
        { 
            this.simulation = simulation;
        }

        public Simulation get_simulation() { return simulation; }

        abstract public void Update();
    }
}

