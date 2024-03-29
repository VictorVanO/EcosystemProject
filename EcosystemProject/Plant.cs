
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EcosystemProject
{
    public class Plant : SimulationObject
    {
        Random random = new Random();

        bool isAlive = true;
        int addPoop = 1;
        
        float rootRadius;
        float semisRadius;

        int checkPoopTimer = 0;
        int spawnPlantTimer = 0;
        int spawnPlantStock = 0;
        public Plant(double x, double y, double health, double energy, float rootRadius, float semisRadius, Simulation simulation,float radius) : base(typeof(Plant),Colors.Green , x, y, health, energy, "", simulation, radius,"")
        {
            this.rootRadius = rootRadius;
            this.semisRadius = semisRadius;
        }
        public float RootRadius { get { return this.rootRadius; } set { this.rootRadius = value; } }
        public float SemisRadius { get { return this.semisRadius; } set { this.semisRadius = value; } }

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
                    Energy -= 0.02;
                }

                checkPoopTimer++;
                if (checkPoopTimer >= 100)
                {
                    checkPoop();
                    checkPoopTimer = 0;
                }

                spawnPlantTimer++;
                if (spawnPlantTimer >= 2000 && spawnPlantStock >= 2) // Spawn a new plant every 20 seconds if spawn plant stock >= 1
                {
                    newPlant();
                    spawnPlantTimer = random.Next(0, 500);
                    spawnPlantStock -= 2;
                }

                // If health is empty, animal dies
                if (Health <= -10) { isAlive = false; }
            }
            // If Plant is dead; set the energy bar to empty , add a Poop and remove the Plant
            if (isAlive == false)
            {
                Energy = -10;
                if (addPoop == 1)
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation(), Radius));
                    addPoop = 0;
                }
                foreach (SimulationObject item in get_simulation().Objects)
                {
                    if (item.X == X & item.Y == Y)
                    {
                        if (item.GetType() == typeof(Plant) && isAlive == false)
                        {
                            get_simulation().Remove(item);
                        }
                    }
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
                canvas.DrawCircle((float)X, (float)Y, Radius * SemisRadius);

                //Zone root
                canvas.StrokeColor = Colors.Brown;
                canvas.DrawCircle((float)X, (float)Y, Radius * RootRadius);
            }
        }

        // Method to check if there is poop in root radius. If yes, then remove the poop
        // and refills the plant's energy.
        public void checkPoop()
        {
            foreach (SimulationObject item in get_simulation().Objects)
            {
                if (item.X >= (X - RootRadius) && item.X <= (X + RootRadius))
                {
                    if (item.Y >= (Y - RootRadius) && item.Y <= (Y + RootRadius))
                    {
                        if (item.GetType() == typeof(Poop))
                        {
                            get_simulation().Remove(item);
                            spawnPlantStock += 1;
                            Energy += 20;
                            if (Energy > 10)
                            {
                                Health += 5;
                                Energy = 10;
                                if (Health > 10)
                                {
                                    Health = 10;
                                }
                            }
                        }
                    }
                }
            }
        }
        //method to add a new plant close to it
        public void newPlant()
        {
            get_simulation().Add(new Plant(random.Next((int)(X - SemisRadius), (int)(X + SemisRadius)), random.Next((int)(Y - SemisRadius), (int)(Y + SemisRadius)), 10, 10, 160, 50, get_simulation(),Radius));
        }
       
    }
}

