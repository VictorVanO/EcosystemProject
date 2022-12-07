using System;
using System.Security.Cryptography.X509Certificates;

namespace EcosystemProject
{
	public class DrawableObject
	{
		Color color;
		float x, y, d,a;
		public DrawableObject(Color color, float x, float y, float d,float a)
		{
			this.color = color;
			this.x = x;
			this.y = y;
			this.d = d;
			this.a = a;
		}

		public Color Color { get { return this.color; } }
		public float X {  get { return this.x; } }
		public float Y {  get { return this.y; } }
        public float D {  get { return this.d; } }
        public float A { get { return this.a; } }
    }
}