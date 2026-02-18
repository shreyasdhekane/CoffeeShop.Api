namespace CoffeeShop.Api.Models;

public class Espresso : BaseCoffee
{
    public override string GetDescription() => "Espresso";
    public override double GetCost() => 2.50;
}