using CoffeeShop.Api.Models;

namespace CoffeeShop.Api.Decorators;

public class CaramelDecorator : CoffeeDecorator
{
    public CaramelDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => $"{_coffee.GetDescription()}, Caramel";
    public override double GetCost() => _coffee.GetCost() + 0.60;
}