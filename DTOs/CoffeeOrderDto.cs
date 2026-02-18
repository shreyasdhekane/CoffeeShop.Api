namespace CoffeeShop.Api.DTOs;

public class CoffeeOrderDto
{
    public string BaseCoffee { get; set; } = string.Empty;
    public List<string> AddOns { get; set; } = new();
}