using System;
using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject
{
	public abstract class DrawableObject
	{
		Color color;
		double x, y, health, energy;
        string gender;
        Type classe;
        public DrawableObject(Type classe, Color color, double x, double y, double health, double energy,string gender)
        {
			this.color = color;
			this.x = x;
			this.y = y;
            this.health = health;
			this.energy = energy;
            this.gender = gender;
            this.classe = classe;
        }

		public Color Color { get { return this.color; } }
        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }
        public double Health { get { return this.health; } set { this.health = value; } }
        public double Energy { get { return this.energy; } set { this.energy = value; } }
        public string Gender { get { return this.gender; } set { this.gender = value; } }
        public Type Classe { get { return this.classe; } set { this.classe = value; } }

    }
}