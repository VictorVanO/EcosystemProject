
using System;
using System.Linq;
namespace EcosystemProject
{
    public class Plant : SimulationObject
    {
        Random random = new Random();

        bool isAlive = true;
        int addPoop = 1;
        int checkPoopTimer = 0;
        public Plant(double x, double y, double health, double energy, float rootRadius, float semisRadius, Simulation simulation) : base(Colors.Green, x, y, health, energy, 150, 60, 0, 0, simulation)
        {
        }
        public override void Update()
        {
            if (isAlive)
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

                checkPoopTimer++;
                if (checkPoopTimer >= 100)
                {
                    // Call the ceckPoop function
                    //checkPoop();
                    checkPoopTimer = 0;
                }
                
                // If health is empty, animal dies
                if (Health <= -10) { isAlive = false; }
                
            }
            if (isAlive == false)
            {
                Energy = -10;
                if (addPoop == 1)
                {
                    get_simulation().objects.Add(new Poop(X, Y, get_simulation()));
                    addPoop = 0;
                }
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
                canvas.DrawCircle((float)X, (float)Y, SemisRadius);

                //Zone root
                canvas.StrokeColor = Colors.Brown;
                canvas.DrawCircle((float)X, (float)Y, RootRadius);
            }
        }

        // Method to check if there is poop in root radius. If yes, then remove the poop
        // and add a plant in the semis radius
        // À terminer, pas encore fonctionnelle
        //public void checkPoop()
        //{
        //    foreach (int x in Enumerable.Range((int)(X - RootRadius), (int)(X + RootRadius)))
        //    {
        //        foreach (int y in Enumerable.Range((int)(Y - RootRadius), (int)(Y + RootRadius)))
        //        {
        //            if (get_simulation().objects.Remove(new Poop(x, y, get_simulation())) != false)
        //            {
        //                get_simulation().objects.Remove(new Poop(x, y, get_simulation()));
        //                get_simulation().objects.Add(new Plant(random.Next((int)(x - SemisRadius), (int)(x + SemisRadius)), random.Next((int)(y - SemisRadius), (int)(y + SemisRadius)), 10, 10, 0, 0, get_simulation()));
        //            }
        //        }
        //    }
                    
        //}
    }
}