namespace MVCIntroExercise.Controllers;

using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Models;

public class ProductController : Controller
{
    private readonly IEnumerable<ProductViewModel> products = new List<ProductViewModel>
    {
        new()
        {
            Id = 1,
            Name = "Cheese",
            Price = 7.00
        },
        new()
        {
            Id = 2,
            Name = "Ham",
            Price = 5.50
        },
        new()
        {
            Id = 3,
            Name = "Bread",
            Price = 1.50
        }
    };

    public IActionResult Index() => RedirectToAction(nameof(All));

    [HttpGet]
    public IActionResult All(string? keyword = null) 
        => View(keyword is null ? products : products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())));

    [HttpGet]
    [ActionName("My-Products")]
    public IActionResult MyProducts(string? keyword = null) => RedirectToAction(nameof(All), new { keyword });

    [HttpGet]
    public IActionResult ById(int id)
    {
        ProductViewModel? product = products.SingleOrDefault(p => p.Id == id);

        if (product is null)
        {
            return BadRequest();
        }

        return View(product);
    }

    [HttpGet]
    public IActionResult AllAsJson() => Json(products, new JsonSerializerOptions
    {
        WriteIndented = true
    });

    [HttpGet]
    public IActionResult AllAsText() => Content(ProductsToString());

    [HttpGet]
    public IActionResult AllAsTextFile()
    {
        Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
        return File(Encoding.UTF8.GetBytes(ProductsToString()), "text/plain");
    }

    private string ProductsToString()
    {
        var sb = new StringBuilder();

        foreach (var product in products)
        {
            sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
        }

        return sb.ToString().TrimEnd();
    }
}