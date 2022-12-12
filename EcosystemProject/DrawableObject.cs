using System;
using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject
{
	public abstract class DrawableObject
	{
		Color color;
		double x, y, health, energy;
		float Øroot, Øsemis, Øvision, Øaction;
        
		public DrawableObject(Color color, double x, double y, double health, double energy,float Øroot, float Øsemis, float Øvision, float Øaction)
		{
			this.color = color;
			this.x = x;
			this.y = y;
            this.health = health;
			this.energy = energy;
			this.Øroot = Øroot;
            this.Øsemis = Øsemis;
            this.Øvision = Øvision;
            this.Øaction = Øaction;
        }

		public Color Color { get { return this.color; } }
        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }
        public double Health { get { return this.health; } set { this.health = value; } }
        public double Energy { get { return this.energy; } set { this.energy = value; } }
        public float ØRoot { get { return this.Øroot; } set { this.Øroot = value; } }
        public float ØSemis { get { return this.Øsemis; } set { this.Øsemis = value; } }
        public float ØVision { get { return this.Øvision; } set { this.Øvision = value; } }
        public float ØAction { get { return this.Øaction; } set { this.Øaction = value; } }

        public abstract void Draw(ICanvas canvas);
    }
}