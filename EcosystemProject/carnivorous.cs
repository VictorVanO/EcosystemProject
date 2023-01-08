

using System;
namespace EcosystemProject
{
    public class Carnivorous : Animal
    {
        
        public Carnivorous(Type classe,Color color, double x, double y, double health, double energy, float visionRadius, float actionRadius, string gender, Simulation simulation,float radius) : base(typeof(Carnivorous),color,x, y, health, energy, 100, 30, gender,"", simulation,radius)
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