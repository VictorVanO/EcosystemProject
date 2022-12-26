using System;
using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject
{
	public abstract class DrawableObject
	{
		Color color;
		double x, y, health, energy;

        float visionRadius;
        float actionRadius = 50;
        public DrawableObject(Color color, double x, double y, double health, double energy, float visionRadius, float actionRadius)
        {
			this.color = color;
			this.x = x;
			this.y = y;
            this.health = health;
            this.energy = energy;
            this.visionRadius = visionRadius;
            this.actionRadius = actionRadius;
        }

		public Color Color { get { return this.color; } }
        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }
        public double Health { get { return this.health; } set { this.health = value; } }
        public double Energy { get { return this.energy; } set { this.energy = value; } }
        public float VisionRadius { get { return this.visionRadius; } set { this.visionRadius = value; } }
        public float ActionRadius { get { return this.actionRadius; } set { this.actionRadius = value; } }

        public abstract void Draw(ICanvas canvas);	
    }
}