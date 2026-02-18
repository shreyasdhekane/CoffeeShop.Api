using CoffeeShop.Api.Models;

namespace CoffeeShop.Api.Factories;

public static class CoffeeFactory
{
    public static ICoffee CreateCoffee(string type)
    {
        Console.WriteLine($"Factory creating: {type}");
        
        return type.ToLower() switch
        {
            "espresso" => new Espresso(),
            "latte" => new Latte(),
            "cappuccino" => new Cappuccino(),
            _ => throw new ArgumentException($"Unknown coffee type: {type}")
        };
    }
}