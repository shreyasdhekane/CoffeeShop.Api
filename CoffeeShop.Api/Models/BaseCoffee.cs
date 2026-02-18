namespace CoffeeShop.Api.Models;

public abstract class BaseCoffee : ICoffee
{
    public abstract string GetDescription();
    public abstract double GetCost();
}