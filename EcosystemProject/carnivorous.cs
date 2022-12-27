
using System;
namespace EcosystemProject
{
    public class carnivorous : Animal
    {
        bool isAlive = true;
        public carnivorous(double x, double y, double health, double energy, float visionRadius, float actionRadius, string gender, Simulation simulation) : base(x, y, health, energy, 100, 30, gender, simulation)
        {

        }
        public override void Update()
        {

        }

        public override void Draw(ICanvas canvas)
        {
        }
    }
}