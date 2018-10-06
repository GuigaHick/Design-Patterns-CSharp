using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRender : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a  circle with radius  {radius}");
        }
    }

    public class RastererRender : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle with radius  {radius}");
        }
    }

    public abstract class Shape 
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float radius;
        public Circle(IRenderer renderer, float radius): base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            this.renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new RastererRender();
            //Or you can render as Vector just creating a renderer object and using New VectorRenderer()
            //renderer = new VectorRender();

            var circle = new Circle(renderer, 87);

            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            Console.ReadKey();
        }
    }
}
