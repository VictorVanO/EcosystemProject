namespace EcosystemProject
{
	public class Simulation : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Drawing code goes here
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;
            canvas.DrawEllipse(10, 10, 100, 100);
        }
    }
}