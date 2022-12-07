using System;
namespace EcosystemProject
{
    public class Poop : SimulationObject
    {
        bool exist = true;
        public Poop(double x, double y) : base(Colors.Brown, x, y, 0, 0)
        {

        }
        public override void Update()
        {
        }

        public override void Draw(ICanvas canvas)
        {
            // Draw poop circle
            canvas.FillColor = Color;
            canvas.FillCircle(new Point(X, Y), 3.0);
        }
    }
}