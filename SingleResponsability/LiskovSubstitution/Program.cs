using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    class Program
    {
        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public Rectangle()
            {

            }

            public Rectangle(int width, int height)
            {
                this.Width = width;
                this.Height = height;
            }

            public override string ToString()
            {
                return $"{nameof(Width) }:{Width},{nameof(Height)} : {Height}";
            }
        }

        public class Square : Rectangle
        {
           public override int Width
            {
                set { base.Height = base.Width = value; }
            }

            public override int Height
            {
                set { base.Height = base.Width = value; }
            }
        }

        static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has Area {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has Area {Area(sq)}");

            Console.ReadKey();
        }
    }
}
