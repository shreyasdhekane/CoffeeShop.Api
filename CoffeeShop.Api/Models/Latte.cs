namespace CoffeeShop.Api.Models;

public class Latte : BaseCoffee
{
    public override string GetDescription() => "Latte";
    public override double GetCost() => 3.50;  
}