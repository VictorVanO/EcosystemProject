
using Microsoft.Maui.Graphics;
using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;


namespace EcosystemProject
{
    public class Animal : SimulationObject
    {
        

        Random random = new Random();
        string[] genders = { "M", "F" };

        string[] moves = { "Up", "Down", "Left", "Right", "Stop" };
        String nextMove = "";
        int moveSpeed = 1;

        double leftX = 10;
        double topY = 10;
        double rightX = 1390;
        double bottomY = 640;

        float visionRadius;
        float actionRadius;

        bool isAlive = true;
        int addMeat = 1;
        int moveTimer = 0;
        int poopTimer = 0;
        int attackTimer = 0;

        public Animal(double x, double y, double health, double energy, float visionRadius, float actionRadius, string gender, Simulation simulation) : base(Colors.Red, x, y, health, energy, gender, simulation)
        {
            this.visionRadius = visionRadius;
            this.actionRadius = actionRadius;
            nextMove = moves[random.Next(moves.Length)]; //The first move direction is random
        }

        public float VisionRadius { get { return this.visionRadius; } set { this.visionRadius = value; } }
        public float ActionRadius { get { return this.actionRadius; } set { this.actionRadius = value; } }
        public override void Update()
        {
            // If animal is alive
            if (isAlive)
            {
                Move();
                CheckAnimal();

                if (Energy <= -10) // If animal has no energy
                {
                    if (Health > -10) // If animal has health, use 5 points to refill energy
                    {
                        Energy = 10;
                        Health -= 5;
                    }
                }
                else // Or if animal has energy
                {
                    Energy -= 0.02; // Lose energy every update
                }

                poopTimer += 1;
                if (poopTimer >= 800) // Poop every 8 seconds
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation()));
                    poopTimer = 0;
                }
            }

            // If health is empty, animal dies
            if (Health <= -10) { isAlive = false; }

            // If animal is dead, set the energy bar to empty and add a meat
            if (isAlive == false)
            {
                
                Energy = -10;
                if (addMeat == 1)
                {
                    get_simulation().Add(new Meat(X, Y, 10, get_simulation()));
                    addMeat = 0;
                    get_simulation().Remove(new Animal(X, Y, 10, 10, 0, 0, Gender, get_simulation()));
                }
            }

        }

        public override void Draw(ICanvas canvas)
        {
            if (isAlive)
            {
                if (Gender == "M")
                {
                    //Animal circle
                    canvas.FillColor = Color;
                }
                else
                {
                    canvas.FillColor = Colors.Pink;
                }
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

                //Zone action
                canvas.StrokeColor = Colors.Red;
                canvas.DrawCircle((float)X, (float)Y, ActionRadius);

                //Zone vision
                canvas.StrokeColor = Colors.LightBlue;
                canvas.DrawCircle((float)X, (float)Y, VisionRadius);
            }
        }

        public void Move()
        {
            // If animal leaves the map, comes back
            if (X <= leftX)
            {
                nextMove = "Right";
            }
            else if (X >= rightX)
            {
                nextMove = "Left";
            }
            else if (Y <= topY)
            {
                nextMove = "Down";
            }
            else if (Y >= bottomY)
            {
                nextMove = "Up";
            }

            // Random Movements
            if (nextMove == "Up")
            {
                Y -= moveSpeed;
            }
            else if (nextMove == "Down")
            {
                Y += moveSpeed;
            }
            else if (nextMove == "Left")
            {
                X -= moveSpeed;
            }
            else if (nextMove == "Right")
            {
                X += moveSpeed;
            }
            else if (nextMove == "Stop") { } // Do nothing
            moveTimer++;
            if (moveTimer >= random.Next(30, 90))
            {
                nextMove = moves[random.Next(moves.Length)];
                moveTimer = 0;
            }
        }
        public void Approaching(SimulationObject item)
        {
        
            if (item.X <= (X - ActionRadius) && item.X <= (X + ActionRadius))
            {
                nextMove = "Left";
            }
            else if (item.X >= (X - ActionRadius) && item.X >= (X + ActionRadius))
            {
                nextMove = "Right";
            }
            else if (item.X >= (X - ActionRadius) && item.X <= (X + ActionRadius))
            {
                if (item.Y <= (Y - ActionRadius) && item.Y <= (Y + ActionRadius))
                {
                    nextMove = "Up";
                }
                else if (item.Y >= (Y - ActionRadius) && item.Y >= (Y + ActionRadius))
                {
                    nextMove = "Down";
                }
                else if (item.Y >= (Y - ActionRadius) && item.Y <= (Y + ActionRadius))
                {
                    nextMove = "Stop";
                    Attack(item);

                }
            }
        }
        public void Attack(SimulationObject item)
        {
            attackTimer++;
            poopTimer = 0;

            if (attackTimer == 100)
            {
                item.Health -= 4;
                attackTimer = 0;
                if (item.Health <= -10)
                {
                    get_simulation().Remove(item);

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
        public void CheckPlant()
        {
            foreach (SimulationObject item in get_simulation().Objects)
            {
                if (item.X >= (X - VisionRadius) && item.X <= (X + VisionRadius))
                {
                    if (item.Y >= (Y - VisionRadius) && item.Y <= (Y + VisionRadius))
                    {
                        if (item.GetType() == typeof(Plant))
                        {
                            Approaching(item);




                        }
                    }
                }
            }
        }
        public void CheckAnimal()
        {
            foreach (SimulationObject item in get_simulation().Objects)
            {
                if (item.X >= (X - VisionRadius)  && item.X <= (X + VisionRadius) && item.X <= (X - 5) || item.X >= (X - VisionRadius) && item.X <= (X + VisionRadius) && item.X >= (X + 5))
                {
                    if (item.Y >= (Y - VisionRadius) && item.Y <= (Y + VisionRadius) && item.Y <= (Y - 5) || item.Y >= (Y - VisionRadius) && item.Y <= (Y + VisionRadius) && item.Y >= (Y + 5))
                    {
                        if (item.GetType() == typeof(Animal))
                        {
                            Approaching(item);




                        }
                    }
                }
            }
        }
        
    }
}
