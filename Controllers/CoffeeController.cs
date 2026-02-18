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
            ICoffee coffee = CoffeeFactory.CreateCoffee(order.BaseCoffee);

            foreach (var addOn in order.AddOns)
            {
                coffee = AddAddOn(coffee, addOn);
            }

            return Ok(new CoffeeResponseDto
            {
                Description = coffee.GetDescription(),
                Cost = coffee.GetCost()
            });
        }
        catch (ArgumentException ex)
        {
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