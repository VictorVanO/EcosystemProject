using System;
namespace EcosystemProject
{
    public class Poop : SimulationObject
    {
        bool exist = true;
        public Poop(double x, double y, Simulation simulation,float radius) : base(typeof(Poop),Colors.SaddleBrown, x, y, 0, 0, "", simulation,radius,"")
        {

        }
        public override void Update()
        {
        }

        public override void Draw(ICanvas canvas)
        {
            if (exist)
            {
                // Draw poop
                canvas.FillColor = Color;
                canvas.FillEllipse((float)X, (float)Y, 11, 7);
            }
        }
    }
}