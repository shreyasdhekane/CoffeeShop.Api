namespace CoffeeShop.Api.Models;

public class Cappuccino : BaseCoffee
{
    public override string GetDescription() => "Cappuccino";
    public override double GetCost() => 3.00;
}