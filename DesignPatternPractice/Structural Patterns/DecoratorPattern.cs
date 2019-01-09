using System;

namespace DesignPatternPractice.Structural_Patterns
{
    //Added functionality on runtime
    public class DecoratorPattern
    {
        public DecoratorPattern()
        {
            IBurger burger = new Burger();
            Console.WriteLine(burger.Display());

            Cheese cheeseBurger = new Cheese(burger);
            Console.WriteLine(cheeseBurger.Display());

            Console.ReadLine();
        }
    }

    //Component
    public interface IBurger
    {
        string Name { get; }
        double Price { get; }
        string Display();
    }

    //Concrete Component
    public sealed class Burger : IBurger
    {
        public string Name => "BBQ Chicken";

        public double Price => 180;

        public string Display()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }

    //Decorator
    public abstract class BurgerDecorator : IBurger
    {
        private IBurger _burger; 
        public BurgerDecorator(IBurger burger)
        {
            _burger = burger;
        }

        public string Name => _burger.Name;

        public double Price => _burger.Price;

        public virtual string Display()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }

    //Concrete Decorator
    public class Cheese : BurgerDecorator
    {
        public Cheese(IBurger burger) : base(burger) { }

        public string Name =>  String.Concat("Cheese ", base.Name);
        public double Price => base.Price + 30;

        public string Display()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }
}
