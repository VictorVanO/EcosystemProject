using Microsoft.Maui.Graphics;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EcosystemProject
{
    public class Animal : SimulationObject
    {
        Random random = new Random();

        string[] genders = { "M", "F" };

        string[] moves = { "Up", "Down", "Left", "Right", "Stop" };
        string nextMove = "Stop";
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
        int readyTimer = 0;
       
        public Animal(Type classe, Color color, double x, double y, double health, double energy, float visionRadius, float actionRadius, string gender,string ready, Simulation simulation, float radius) : base(classe,color, x, y, health, energy, gender, simulation, radius,ready)
        {
            this.visionRadius = visionRadius;
            this.actionRadius = actionRadius;
        }

        public float VisionRadius { get { return this.visionRadius; } set { this.visionRadius = value; } }
        public float ActionRadius { get { return this.actionRadius; } set { this.actionRadius = value; } }
        
       
        public override void Update()
        {
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
                }
                else // Or if animal has energy
                {
                    Energy -= 0.01; // Lose energy every update
                }

                poopTimer += 1;
                if (poopTimer >= 800) // Poop every 8 seconds
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation(), Radius));
                    poopTimer = 0;
                }

                // If health is empty, animal dies
                if (Health <= -10) { isAlive = false; }
            }
            // If animal is dead; set the energy bar to empty , add a meat and remove the animal
            if (isAlive == false)
            {
                Energy = -10;
                if (addMeat == 1)
                {
                    get_simulation().Add(new Meat(X, Y, 10, get_simulation(), Radius));
                    
                    addMeat = 0;
                    Ready = "No";
                }
                foreach (SimulationObject item in get_simulation().Objects)
                {
                    if (item.X == X & item.Y == Y)
                    {
                        if (item.GetType() == typeof(Animal) && isAlive == false)
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
                //depending on the gender the Animal has a different color

                if (Classe == typeof(Carnivorous))
                    
                    if (Gender == "M")
                    {
                        canvas.FillColor = Colors.Red;
                    }
                    else
                    {
                        canvas.FillColor = Colors.Pink;
                    }

                if (Classe == typeof(Herbivorous))

                    if (Gender == "M")
                    {
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
                canvas.DrawCircle((float)X, (float)Y, Radius * ActionRadius);
                //Zone vision
                canvas.StrokeColor = Colors.White;
                canvas.DrawCircle((float)X, (float)Y, Radius * VisionRadius);
                
                //if the Animal is ready to reproduct, draw a heart above him
                if (Ready == "Yes")
                {
                    canvas.StrokeColor = Colors.Red;
                    canvas.StrokeSize = 1;
                    canvas.DrawLine((float)X, (float)Y - 26, (float)X + 4, (float)Y - 31);
                    canvas.DrawLine((float)X, (float)Y - 26, (float)X - 4, (float)Y - 31);
                    canvas.FillColor = Colors.Red;
                    canvas.DrawArc((float)X , (float)Y - 34,  4, 6, 0, 180, false,false);
                    canvas.DrawArc((float)X - 4, (float)Y - 34, 4, 6, 0, 180, false,false);

                    //if the animal has been ready for 10 seconds and anything happend, he is no longer ready
                    readyTimer++;
                    if (readyTimer >= 1000)
                    {
                        readyTimer = 0;
                        Ready = "No";
                    }
                }

                //if the animal is ready but escaping from a predator, the heart tunrs black and when he is out of danger he is ready again
                else if (Ready == "Not now")
                {
                    canvas.StrokeColor = Colors.Black;
                    canvas.StrokeSize = 1;
                    canvas.DrawLine((float)X, (float)Y - 26, (float)X + 4, (float)Y - 31);
                    canvas.DrawLine((float)X, (float)Y - 26, (float)X - 4, (float)Y - 31);
                    canvas.FillColor = Colors.Black;
                    canvas.DrawArc((float)X, (float)Y - 34, 4, 6, 0, 180, false, false);
                    canvas.DrawArc((float)X - 4, (float)Y - 34, 4, 6, 0, 180, false, false);
                    Ready = "Yes";
                }
                else if(Ready == "No")
                { readyTimer = 0; }
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
            // Do nothing
            else if (nextMove == "Stop") { }

            moveTimer++;
            if (moveTimer >= random.Next(30, 90))
            {
                nextMove = moves[random.Next(moves.Length)];
                moveTimer = 0;
            }
        }
        public void Approaching(SimulationObject item )
        {
            //the animal come closer to the item until he is at the ActionRadius' distance, then it stop
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

        public void Escape(SimulationObject item)
        {
            //the animal go away from the item
            if (item.X <= (X - ActionRadius) && item.X <= (X + ActionRadius))
            {
                nextMove = "Right";
            }
            else if (item.X >= (X - ActionRadius) && item.X >= (X + ActionRadius))
            {
                nextMove = "Left";
            }
            else if (item.X >= (X - ActionRadius) | item.X <= (X + ActionRadius))
            {
                if (item.Y <= (Y - ActionRadius) && item.Y <= (Y + ActionRadius))
                {
                    nextMove = "Down";
                }
                else if (item.Y >= (Y - ActionRadius) && item.Y < Y )
                {
                    nextMove = "Down";

                    if (bottomY <= (Y + actionRadius) && item.Y >= (Y - ActionRadius) & item.Y < Y)
                    {
                        nextMove = "Right";
                    }
                }
                else if (item.Y >= (Y - ActionRadius) && item.Y >= (Y + ActionRadius))
                {
                    nextMove = "Up";
                    
                }
                else if (item.Y <= (Y + ActionRadius) && item.Y > Y)
                {
                    nextMove = "Up";

                    if (topY >= (Y - ActionRadius) && item.Y <= (Y + ActionRadius) & item.Y > Y)
                    {
                        nextMove = "Left";
                    }
                }
            }
        }

        public void Attack(SimulationObject item)
        {
            Approaching(item);
            attackTimer++;
            poopTimer = 0;

            //each seconds the animal low the item's life by 4 and when it is dead, it removes it and add a meat instead
            if (attackTimer >= 100 && (item.X >= (X - ActionRadius) & item.X <= (X + ActionRadius) && item.Y >= (Y - ActionRadius) & item.Y <= (Y + ActionRadius)))
            {
                item.Health -= 4;
                attackTimer = 0;
                if (item.Health <= -10)
                {
                    get_simulation().Remove(item);
                    get_simulation().Add(new Meat(item.X, item.Y, 10, get_simulation(), Radius));
                }
            }
        }

        public void Eat(SimulationObject item)
        {
            Approaching(item);
            attackTimer++;
            poopTimer = 0;

            //each seconds the animal low the item's life by 5 and refill his Energy by 8
            if (attackTimer >= 100 && nextMove == "Stop")
            {
                item.Health -= 5;
                attackTimer = 0;
                Energy += 8;
                Ready = "Yes";
                    
                if (Energy > 10)
                {
                    //when his Energy is bigger than the max he gain 5 points of health and add the rest of the Energy to the following bar
                    if(Health < 10)
                    {
                        Health += 5;
                        Energy -= 20;
                    }
                    //when both his Energy and his Health are bigger than the max they limit iself at the max
                    if (Health >= 10 & Energy >= 10)
                    {
                        Health = 10;
                        Energy = 10;
                    }
                }
                //when the item has no health it dies
                if (item.Health <= -10)
                {
                    get_simulation().Remove(item);
                    readyTimer = 0;
                }
            }
        }
        public void Reproduct(SimulationObject item,Type Classe)
        {
            readyTimer = 0;
            Approaching(item);
            poopTimer = 0;
            
            //when the Animal is close enough, he wait for 5 seconds
            if (nextMove == "Stop" )
            {
                readyTimer = 750;
                ReproductTimer += 1;

                //if its a male it does nothing but he stands Ready for 2.5 seconds more
                if (Gender == "M" & ReproductTimer >= 510)
                {}
                //if its a female she create an Animal and become not ready
                else if(Gender == "F" & ReproductTimer >= 500 )
                {
                    get_simulation().Add(new Animal(Classe, Color, X, Y, 10, 10, 100, 30, genders[random.Next(genders.Length)], "No", get_simulation(), Radius));
                    Ready = "No";
                    ReproductTimer = 0;
                }
            }
        }
        public void CheckEntities(Type Classe)
        {
            //Checks All the Entities on the Animal's sight
            foreach (SimulationObject item in get_simulation().Objects)
            {
                if (item.X >= (X - VisionRadius) && item.X <= (X + VisionRadius))
                {
                    if (item.Y >= (Y - VisionRadius) && item.Y <= (Y + VisionRadius))
                    {
                        //if the Animal is a carnivorous
                        if (Classe == typeof(Carnivorous))
                        {
                            //he chase an herbivorous
                            if (item.Classe == typeof(Herbivorous))
                            {
                                Attack(item);
                            }
                            //he eats the Meat if he is Hungry
                            if (item.GetType() == typeof(Meat))
                            {
                                if (Health == 10 & Energy >= 0)
                                { }
                                else { Eat(item); }
                            }
                        }
                        //if the Animal is a herbivorous
                        if (Classe == typeof(Herbivorous))
                        {
                            moveSpeed = 2;
                            //he runs aways from the carnivorous
                            if (item.Classe == typeof(Carnivorous))
                            {
                                Escape(item);
                                if (Ready == "Yes")
                                {
                                    Ready = "Not now";
                                }
                            }
                            //he eats the plant if he is Hungry
                            if (item.GetType() == typeof(Plant))
                            {
                                if (Health == 10 & Energy >= 0)
                                { }
                                else { Eat(item); }
                            }
                        }
                        //if the Animal sees an item who has the same class as him, the opposite gender and that they are both Ready, they reproduct
                        if (item.Classe == Classe && item.Gender != Gender && Ready == "Yes" & item.Ready == "Yes")
                        {
                            Reproduct(item, Classe);
                        }
                    }
                }
            }
        }
    }
}
