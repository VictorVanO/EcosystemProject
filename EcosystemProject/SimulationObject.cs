using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        public SimulationObject(Color color, double x, double y) : base(color, x, y) { }

        abstract public void Update();
    }
}

