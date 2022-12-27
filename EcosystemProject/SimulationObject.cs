using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        private Simulation simulation;
        public SimulationObject(Color color, double x, double y, double health, double energy, float rootRadius, float semisRadius, float visionRadius, float actionRadius, string gender, Simulation simulation) : base(color, x, y, health, energy, rootRadius, semisRadius, visionRadius, actionRadius, gender)
        { 
            this.simulation = simulation;
        }

        public Simulation get_simulation() { return simulation; }

        abstract public void Update();
    }
}

