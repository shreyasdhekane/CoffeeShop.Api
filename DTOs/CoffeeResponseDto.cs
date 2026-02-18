namespace CoffeeShop.Api.DTOs;

public class CoffeeResponseDto
{
    public string Description { get; set; } = string.Empty;
    public double Cost { get; set; }
    public string FormattedCost => $"${Cost:F2}";
}