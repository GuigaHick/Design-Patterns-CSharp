using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoObserver
{
    public class FalssIllEventArgs 
    {
        public string Address;
    }


    public class Person
    {
        public void CatchACold()
        {
            FalssIll?.Invoke(this,  new FalssIllEventArgs { Address = "123 London Road" });
        }
        public event EventHandler<FalssIllEventArgs> FalssIll;

    }


    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.FalssIll += CallADoctor;

            Console.WriteLine("Person's health is ok.If you press a key a person gonna catch a cold");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Person caught a cold");
            p.CatchACold();
            Console.ReadKey();
        }

        private static void CallADoctor(object sender, FalssIllEventArgs e)
        {
            Console.WriteLine($"A doctor has been called to { e.Address}");
        }
    }
}
