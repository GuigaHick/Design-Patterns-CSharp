using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInnerFactory
{
    public class Point
    {
        private double x;
        private double y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $" {nameof(x)}: {x},{nameof(y)} : {y}";
        }

        public static class Factory
        {
            //Factory Method
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }

            //Factory Method
            public static Point NewCartesianPoint(int x, int y)
            {
                return new Point(x, y);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewCartesianPoint(87, 90);
            Console.WriteLine(point.ToString());
            var point2 = Point.Factory.NewPolarPoint(1, Math.PI/2);
            Console.WriteLine(point2.ToString());
            

            Console.ReadKey();
        }
    }
}
