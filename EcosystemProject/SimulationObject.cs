using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        public SimulationObject(Color color, double x, double y, double health, double energy, float �root, float �semis, float �vision, float �action) : base(color, x, y, health, energy, �root, �semis, �vision, �action) { }

        abstract public void Update();
    }
}

