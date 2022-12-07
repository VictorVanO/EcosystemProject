using System;
namespace EcosystemProject
{
    public abstract class SimulationObject : DrawableObject
    {
        public SimulationObject(Color color, double x, double y, double health, double energy, float Øroot, float Øsemis, float Øvision, float Øaction) : base(color, x, y, health, energy, Øroot, Øsemis, Øvision, Øaction) { }

        abstract public void Update();
    }
}

