
using Microsoft.Maui.Graphics;
using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EcosystemProject
{
    public class Animal : SimulationObject
    {
        List<SimulationObject> objects;

        Simulation Simulation;

        Random random = new Random();
        string[] moves = { "Up", "Down", "Left", "Right", "Stop" };
        string nextMove = "";
        int moveTimer = 0;
        int moveSpeed = 1;
        bool isAlive = true;
        int poopTimer = 0;

        double poopX = 200;
        double poopY = 200;
        public Animal(double x, double y, double health, double energy, float Øroot, float Øsemis, float Øvision, float Øaction) : base(Colors.Red, x, y, health, energy,  0,0, 100, 30)
        {
            nextMove = moves[random.Next(moves.Length)]; //The first move direction is random
            objects = new List<SimulationObject>();
        }
        public override void Update()
        {
            // If animal is alive
            if(isAlive)
            {
                // Random Movements
                if (nextMove == "Up")
                {
                    Y -= moveSpeed;
                    if(Y ==0)
                    {
                        Y += 10;
                    }
                }
                else if (nextMove == "Down")
                {
                    Y += moveSpeed;
                    if (Y == 700)
                    {
                        Y -= 10;
                    }
                }
                else if (nextMove == "Left")
                {
                    X -= moveSpeed;
                    if (X == 0)
                    {
                        X += 10;
                    }
                }
                else if (nextMove == "Right")
                {
                    X += moveSpeed;
                    if (X == 1400)
                    {
                        X -= 10;
                    }
                }
                else if (nextMove == "Stop") { } // Do nothing
                moveTimer++;
                if (moveTimer >= random.Next(30, 90))
                {
                    nextMove = moves[random.Next(moves.Length)];
                    moveTimer = 0;
                }

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
                    Energy -= 0.01; // Lose energy every update
                }

                poopTimer += 5;
            }

            // If health is empty, animal dies
            if (Health <= -10) { isAlive = false; }

            // If animal is dead, set the energy bar to empty
            if(isAlive == false)
            {
                Energy = -10;
            }
        }

        public override void Draw(ICanvas canvas)
        {
            if (isAlive)
            {
                //Animal circle
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

                //Zone action
                canvas.StrokeColor = Colors.Red;
                canvas.DrawCircle((float)X, (float)Y, ØAction);

                //Zone vision
                canvas.StrokeColor = Colors.LightBlue;
                canvas.DrawCircle((float)X, (float)Y, ØVision);
            }

            if (isAlive == false)
            {
                //objects.Add(new Meat(X, Y));
            }

            if (poopTimer >= 100)
            {
                objects.Add(new Poop(X, Y));
                poopTimer = 0;
            }
        }
    }
}