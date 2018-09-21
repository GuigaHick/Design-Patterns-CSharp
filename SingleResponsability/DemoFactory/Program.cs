using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFactory
{
    public class Point
    {
        private double x;
        private double y;

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

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $" {nameof(x)}: {x},{nameof(y)} : {y}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var polarPoint = Point.NewPolarPoint(1, Math.PI / 2);
            Console.WriteLine(polarPoint.ToString());

            var cartesianPoint = Point.NewCartesianPoint(1,2);
            Console.WriteLine(cartesianPoint.ToString());

            Console.ReadKey();
        }
    }
}
