using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAbstractFactory
{
    public interface IHotDrink
    {
        void Consume(int amount);
    }

    internal class Tea : IHotDrink
    {
        public void Consume(int amount)
        {
            Console.WriteLine("This Tea Is Nice");
        }
    }

    internal class Coffe : IHotDrink
    {
        public void Consume(int amount)
        {
            Console.WriteLine("This Coffe Is Nice");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea bag, boil a water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind Some Beans, boil  water,pour {amount} ml, add cream and sugar");
            return new Coffe();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffe,Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach(AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("DemoAbstractFactory." + Enum.GetName(typeof(AvailableDrink),drink) + "Factory"));
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffe, 2);
            drink.Consume(1);
            Console.ReadKey();
        }
    }
}
