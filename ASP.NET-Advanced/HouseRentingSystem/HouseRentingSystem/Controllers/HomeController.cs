namespace HouseRentingSystem.Controllers;

using Microsoft.AspNetCore.Mvc;
using Core.Services.Contracts.House;

public class HomeController(IHouseService houseService) : Controller
{
    public async Task<IActionResult> Index() => View(await houseService.GetLastThreeHousesAsync());

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int statusCode)
        => statusCode switch
        {
            400 => View("Error400"),
            401 => View("Error401"),
            _ => View()
        };
}