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

            IBurger cheeseBurger = new Cheese(new Cheese(burger));
            Console.WriteLine(cheeseBurger.Display());

            Console.ReadLine();
        }
    }

    //Component
    public interface IBurger
    {
        string GetName();
        double GetPrice();
        string Display();
    }

    //Concrete Component
    public sealed class Burger : IBurger
    {
        public string GetName() { return "BBQ Chicken"; }

        public double GetPrice() { return 180; }

        public string Display()
        {
            return $"Name: {GetName()}, Price: {GetPrice()}";
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

        public virtual string GetName()
        {
            return _burger.GetName();
        }

        public virtual double GetPrice()
        {
            return _burger.GetPrice();
        }

        public string Display()
        {
            return $"Name: {GetName()}, Price: {GetPrice()}";
        }
    }

    //Concrete Decorator
    public class Cheese : BurgerDecorator
    {
        public Cheese(IBurger burger) : base(burger) { }
        public override string GetName()
        {
            return $" Cheese {base.GetName()}";
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 30;
        }
    }
}
