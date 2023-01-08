using System;
namespace EcosystemProject
{
    public class Meat : SimulationObject
    {
        bool exist = true;
        int addPoop = 1;
        public Meat(double x, double y, double health, Simulation simulation,float radius) : base(typeof(Meat),Colors.IndianRed, x, y, 10, 0, "",simulation,radius, "")
        {}
        public override void Update()
        {
            //the meat loses Energy over time
            if (exist)
            {
                Health -= 0.01;
            }
            // If health is empty, remove meat and add poop instead
            if (Health <= -10) 
            {
                exist = false;
                foreach (SimulationObject item in get_simulation().Objects)
                {
                    if (item.X == X & item.Y == Y)
                    {   
                        if (item.GetType() == typeof(Meat) && exist == false)
                        { 
                            get_simulation().Remove(item);
                        }
                    }
                }
                if (addPoop == 1)
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation(),Radius));
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
                canvas.FillCircle(new Point((float)X, (float)Y), 7.0);

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