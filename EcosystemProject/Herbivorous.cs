
using System;
namespace EcosystemProject
{
    public class Herbivorous : Animal
    {
        
        public Herbivorous(Type classe,Color color, double x, double y, double health, double energy, float visionRadius, float actionRadius, string gender,string Ready, Simulation simulation,float radius) : base(classe,color, x, y, health, energy, 100, 30, gender,"", simulation,radius)
        {

        }
        public override void Update()
        {

        }

        public override void Draw(ICanvas canvas)
        {
            
            
        }
    }
}