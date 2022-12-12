using System;
using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject
{
	public abstract class DrawableObject
	{
		Color color;
		double x, y, health, energy;
		float �root, �semis, �vision, �action;
        
		public DrawableObject(Color color, double x, double y, double health, double energy,float �root, float �semis, float �vision, float �action)
		{
			this.color = color;
			this.x = x;
			this.y = y;
            this.health = health;
			this.energy = energy;
			this.�root = �root;
            this.�semis = �semis;
            this.�vision = �vision;
            this.�action = �action;
        }

		public Color Color { get { return this.color; } }
        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }
        public double Health { get { return this.health; } set { this.health = value; } }
        public double Energy { get { return this.energy; } set { this.energy = value; } }
        public float �Root { get { return this.�root; } set { this.�root = value; } }
        public float �Semis { get { return this.�semis; } set { this.�semis = value; } }
        public float �Vision { get { return this.�vision; } set { this.�vision = value; } }
        public float �Action { get { return this.�action; } set { this.�action = value; } }

        public abstract void Draw(ICanvas canvas);
    }
}