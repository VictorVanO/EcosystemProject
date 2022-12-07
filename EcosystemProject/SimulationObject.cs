using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        public SimulationObject(Color color, double x, double y, double health, double energy) : base(color, x, y, health, energy) { }

        abstract public void Update();
    }
}

