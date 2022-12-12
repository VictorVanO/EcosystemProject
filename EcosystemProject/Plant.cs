using System;
namespace EcosystemProject
{
    public class Plant : SimulationObject
    {
        bool isAlive = true;
        public Plant(double x, double y, double health, double energy, float Øroot, float Øsemis, float Øvision, float Øaction, Simulation simulation) : base(Colors.Green, x, y, health, energy, 150, 60, 0, 0, simulation)
        {

        }
        public override void Update()
        {
            // If plant has energy, lower energy bar
            if (Energy <= -10)
            {
                // If energy bar equal 0, refill it for 5 health point
                if (Health > -10)
                {
                    Energy = 10;
                    Health -= 5;
                }
            }
            else
            {
                Energy -= 0.01;
            }

            // If health is empty, animal dies
            if (Health <= -10) { isAlive = false; }

            if(isAlive == false)
            {
                Energy = -10;
            }
        }

        public override void Draw(ICanvas canvas)
        {
            if (isAlive)
            {
                //Plant circle
                canvas.FillColor = Color;
                canvas.FillCircle(new Point(X, Y), 10.0);

                //Health bar shadow
                canvas.StrokeColor = Colors.DarkGray;
                canvas.StrokeSize = 3;
                canvas.DrawLine((float)X - 10, (float)Y - 20, (float)X + 10, (float)Y - 20);
                //Energy bar shadow
                canvas.StrokeColor = Colors.DarkGray;
                canvas.StrokeSize = 3;
                canvas.DrawLine((float)X - 10, (float)Y - 15, (float)X + 10, (float)Y - 15);

                //Health bar
                canvas.StrokeColor = Colors.DarkGreen;
                canvas.StrokeSize = 3;
                canvas.DrawLine((float)X - 10, (float)Y - 20, (float)X + (float)Health, (float)Y - 20);

                //Energy bar
                canvas.StrokeColor = Colors.Yellow;
                canvas.StrokeSize = 3;
                canvas.DrawLine((float)X - 10, (float)Y - 15, (float)X + (float)Energy, (float)Y - 15);

                //Zone semis
                canvas.StrokeColor = Colors.DarkGreen;
                canvas.DrawCircle((float)X, (float)Y, ØSemis);

                //Zone root
                canvas.StrokeColor = Colors.Brown;
                canvas.DrawCircle((float)X, (float)Y, ØRoot);
            }
        }
    }
}