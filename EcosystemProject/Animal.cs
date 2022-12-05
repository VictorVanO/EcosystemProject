using System;

namespace EcosystemProject
{
    public class Animal : SimulationObject
    {
        Random random = new Random();
        string[] moves = { "Up", "Down", "Left", "Right" };
        string nextMove = "Up";
        int moveTimer = 0;
        int moveSpeed = 2;
        public Animal(double x, double y) : base(Colors.Red, x, y)
        {
            //nextMove = moves[random.Next(moves.Length)];
        }
        public override void Update()
        {   
            if(nextMove == "Up")
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

            moveTimer++;
            if (moveTimer >= random.Next(20, 100))
            {
                nextMove = moves[random.Next(moves.Length)];
                moveTimer = 0;
            }
            //if (nextMove == "Up")
            //{
            //    Y -= 1;
            //    moveTimer++;
            //    if (moveTimer >= 50)
            //    {
            //        nextMove = moves[random.Next(moves.Length)];
            //    }
            //}
            //else if (nextMove == "Down")
            //{
            //    Y += 1;
            //    moveTimer++;
            //    if (moveTimer >= 50)
            //    {
            //        nextMove = moves[random.Next(moves.Length)];
            //    }
            //}
            //else if (nextMove == "Left")
            //{
            //    X -= 1;
            //    moveTimer++;
            //    if (moveTimer >= 50)
            //    {
            //        nextMove = moves[random.Next(moves.Length)];
            //    }
            //}
            //else if (nextMove == "Right")
            //{
            //    X += 1;
            //    moveTimer++;
            //    if (moveTimer >= 50)
            //    {
            //        nextMove = moves[random.Next(moves.Length)];
            //    }
            //}

            //X += random.Next(-1, 1);
            //Y += random.Next(-1, 1);
        }
    }
}