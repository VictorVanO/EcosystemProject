
using Microsoft.Maui.Graphics;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;


namespace EcosystemProject
{
    public class Animal : SimulationObject
    {
        Type[] Classes = { typeof(Carnivorous), typeof(Herbivorous) };

        

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
        int ReproductTimer = 0;
        string Ready = "No";

        public Animal(Type classe, Color color, double x, double y, double health, double energy, float visionRadius, float actionRadius, string gender, Simulation simulation) : base(classe,color, x, y, health, energy, gender, simulation)
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
                CheckEntities(Classe);



                if (Energy <= -10) // If animal has no energy
                {
                    if (Health > -10) // If animal has health, use 5 points to refill energy
                    {
                        Energy = 10;
                        Health -= 5;
                    }
                    // If health is empty, animal dies
                    if (Health <= -10) { isAlive = false; }
                }
                else // Or if animal has energy
                {
                    Energy -= 0.005; // Lose energy every update
                }

                poopTimer += 1;
                if (poopTimer >= 800) // Poop every 8 seconds
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation()));
                    poopTimer = 0;
                }
            }

           

            // If animal is dead, set the energy bar to empty and add a meat
            if (isAlive == false)
            {
                
                Energy = -10;
                if (addMeat == 1)
                {
                    get_simulation().Add(new Meat(X, Y, 10, get_simulation()));
                    addMeat = 0;
                    get_simulation().Remove(new Animal(Classe,Color,X, Y, 10, 10, 0, 0, Gender, get_simulation()));
                }
            }

        }

        public override void Draw(ICanvas canvas)
        {
            if (isAlive)
            {
                if (Classe == typeof(Carnivorous))

                    if (Gender == "M")
                    {
                        //Animal circle
                        canvas.FillColor = Colors.Red;
                    }
                    else
                    {
                        canvas.FillColor = Colors.Pink;
                    }
                if (Classe == typeof(Herbivorous))

                    if (Gender == "M")
                    {
                        //Animal circle
                        canvas.FillColor = Colors.DarkBlue;
                    }
                    else
                    {
                        canvas.FillColor = Colors.Blue;
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
        public void Approaching(SimulationObject item )
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
                }
            }

        }
        public void nigerooo(SimulationObject item)
        {

            moveSpeed = 2;

            if (item.X <= (X - ActionRadius) && item.X <= (X + ActionRadius))
            {
                nextMove = "Right";
            }
            else if (item.X >= (X - ActionRadius) && item.X >= (X + ActionRadius))
            {
                nextMove = "Left";
            }
            else if (item.X <= (X - ActionRadius) | item.X >= (X + ActionRadius))
            {
                if (item.Y <= (Y - ActionRadius) && item.Y <= (Y + ActionRadius))
                {
                    nextMove = "Down";
                }
                else if (item.Y >= (Y - ActionRadius) && item.Y >= (Y + ActionRadius))
                {
                    nextMove = "Up";
                    
                }
            }
        }
        public void Attack(SimulationObject item)
        {
            Approaching(item);
            attackTimer++;
            poopTimer = 0;

            if (attackTimer >= 100 && (item.X >= (X - ActionRadius) & item.X <= (X + ActionRadius) && item.Y >= (Y - ActionRadius) & item.Y <= (Y + ActionRadius)))
            {
                item.Health -= 4;
                attackTimer = 0;
                if (item.Health <= -10)
                {
                    get_simulation().Remove(item);
                    get_simulation().Add(new Meat(item.X, item.Y, 10, get_simulation()));
                }

            }
        }

        public void Eat(SimulationObject item)
        {
            Approaching(item);

            attackTimer++;
            poopTimer = 0;
            //if (Health == 10 & Energy >= 0)
            //{
                //Move()
            //}
            if (attackTimer >= 100 && nextMove == "Stop")
            {
                item.Health -= 5;
                attackTimer = 0;
                Energy += 6;
                    
                if (Energy > 10)
                {
                    if(Health < 10)
                    {
                        Health += 5;
                        Energy -= 20;
                    }
                    
                    if (Health >= 10)
                    {
                        Health = 10;
                        Energy = 10;
                    }
                }
                if (item.Health <= -10)
                {
                    get_simulation().Remove(item);
                    Ready = "Yes";
                }
            }
        }
        public void Reproduct(SimulationObject item,Type Classe)
        {
            Approaching(item);
            poopTimer = 0;
            ReproductTimer++;
            if (nextMove == "Stop" && ReproductTimer >= 500 )
            {
                if(Gender == "F")
                {
                    
                    get_simulation().Add(new Animal(Classe, Color, X, Y, 10, 10, 100, 30, genders[random.Next(genders.Length)], get_simulation()));

                    ReproductTimer = 0;
                    Ready = "No";
                }
                
                ReproductTimer = 0;
                
                Ready = "No";
                
            }
        }
        public void CheckEntities(Type Classe)
        {
            foreach (SimulationObject item in get_simulation().Objects)
            {
                if (item.X >= (X - VisionRadius) && item.X <= (X + VisionRadius))
                {
                    if (item.Y >= (Y - VisionRadius) && item.Y <= (Y + VisionRadius))
                    {   
                        if (Classe == typeof(Carnivorous))
                        {
                            if (item.Classe == typeof(Herbivorous))
                            {
                                Attack(item);
                            }
                            if (item.GetType() == typeof(Meat))
                            {
                                Eat(item);
                            }
                            
                        }
                        if (Classe == typeof(Herbivorous))
                        {
                           
                            if (item.Classe == typeof(Carnivorous))
                            {
                                
                                nigerooo(item);
                                
                            }
                            if (item.GetType() == typeof(Plant))
                            {
                                Eat(item);
                            }
                            
                        }
                        if (item.Classe == Classe && item.Gender != Gender && Ready == "Yes")
                        {
                            Reproduct(item, Classe);
                        }
                    }
                }
            }
        }



    }
}
