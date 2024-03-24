using System;

using System;

// Interfejs kawy
interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Klasa podstawowej kawy
class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Kawa";
    }

    public double GetCost()
    {
        return 1.0;
    }
}

// Dekorator dodający mleko
class MilkDecorator : ICoffee
{
    private ICoffee _coffee;

    public MilkDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public string GetDescription()
    {
        return _coffee.GetDescription() + ", z mlekiem";
    }

    public double GetCost()
    {
        return _coffee.GetCost() + 0.5;
    }
}

// Dekorator dodający cukier
class SugarDecorator : ICoffee
{
    private ICoffee _coffee;

    public SugarDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public string GetDescription()
    {
        return _coffee.GetDescription() + ", z cukrem";
    }

    public double GetCost()
    {
        return _coffee.GetCost() + 0.2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Zamawianie kawy z mlekiem i cukrem
        ICoffee coffee = new SimpleCoffee();
        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);

        Console.WriteLine("Zamówienie: " + coffee.GetDescription());
        Console.WriteLine("Koszt: $" + coffee.GetCost());
    }
}
