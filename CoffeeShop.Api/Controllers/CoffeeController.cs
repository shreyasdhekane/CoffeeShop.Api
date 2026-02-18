using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Api.DTOs;
using CoffeeShop.Api.Factories;
using CoffeeShop.Api.Decorators;
using CoffeeShop.Api.Models;

namespace CoffeeShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeController : ControllerBase
{
    [HttpPost("order")]
    public ActionResult<CoffeeResponseDto> OrderCoffee([FromBody] CoffeeOrderDto order)
    {
        try
        {
            Console.WriteLine($"=== Order Received ===");
            Console.WriteLine($"Base Coffee: {order.BaseCoffee}");
            Console.WriteLine($"Add-ons: {string.Join(", ", order.AddOns)}");
            
            // Factory Pattern: Create base coffee
            ICoffee coffee = CoffeeFactory.CreateCoffee(order.BaseCoffee);
            Console.WriteLine($"Created base: {coffee.GetDescription()} - ${coffee.GetCost()}");

            // Decorator Pattern: Apply add-ons
            foreach (var addOn in order.AddOns)
            {
                coffee = AddAddOn(coffee, addOn);
                Console.WriteLine($"After adding {addOn}: {coffee.GetDescription()} - ${coffee.GetCost()}");
            }

            var response = new CoffeeResponseDto
            {
                Description = coffee.GetDescription(),
                Cost = coffee.GetCost()
            };
            
            Console.WriteLine($"Final: {response.Description} - ${response.Cost}");
            Console.WriteLine($"===================");

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("menu")]
    public ActionResult<object> GetMenu()
    {
        var baseCoffees = new[] { "Espresso", "Latte", "Cappuccino" };
        var addOns = new[] { "Milk", "Sugar", "WhippedCream", "Caramel" };

        return Ok(new { baseCoffees, addOns });
    }

    private ICoffee AddAddOn(ICoffee coffee, string addOn)
    {
        return addOn.ToLower() switch
        {
            "milk" => new MilkDecorator(coffee),
            "sugar" => new SugarDecorator(coffee),
            "whippedcream" => new WhippedCreamDecorator(coffee),
            "caramel" => new CaramelDecorator(coffee),
            _ => coffee
        };
    }
}