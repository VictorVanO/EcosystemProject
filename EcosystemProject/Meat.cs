using System;
namespace EcosystemProject
{
    public class Meat : SimulationObject
    {
        bool exist = true;
        int addPoop = 1;
        public Meat(double x, double y, double health, Simulation simulation) : base(Colors.IndianRed, x, y, 10, 0, 0, 0, 0, 0, simulation)
        {

        }
        public override void Update()
        {
            if (exist)
            {
                Health -= 0.01;
            }
            // If health is empty, meat becomes poop
            if (Health <= -10) 
            { 
                exist = false;
                if (addPoop == 1)
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation()));
                    addPoop = 0;
                }
            }
        }

        public override void Draw(ICanvas canvas)
        {
            if (exist)
            {
                // Draw Meat
                canvas.FillColor = Color;
                canvas.FillCircle(new Point((float)X, (float)Y), 6.0);

                //Health bar shadow
                canvas.StrokeColor = Colors.DarkGray;
                canvas.StrokeSize = 3;
                canvas.DrawLine((float)X - 10, (float)Y - 15, (float)X + 10, (float)Y - 15);
                //Health bar
                canvas.StrokeColor = Colors.DarkGreen;
                canvas.StrokeSize = 3;
                canvas.DrawLine((float)X - 10, (float)Y - 15, (float)X + (float)Health, (float)Y - 15);
            }
        }
    }
}