namespace ProductsApi.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using Services;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService products) : Controller
{
    /// <summary>
    /// Gets a list of all products.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/products
    ///     {
    ///
    ///     }
    /// </remarks>
    /// <response code="200">Returns "OK" with a list of all products</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts() => Ok(await products.GetAllAsync());

    /// <summary>
    /// Gets a product by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/products/{id}
    ///     {
    ///
    ///     }
    /// </remarks>
    /// <response code="200">Returns "OK" with the product</response>
    /// <response code="404">Returns "Not Found" when a product with the given id doesn't exist</response>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        Product? product = await products.GetByIdAsync(id);
        return product != null ? product : NotFound();
    }

    /// <summary>
    /// Creates a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/products
    ///     {
    ///         "name": "Candy",
    ///         "description": "Chocolate"
    ///     }
    /// </remarks>
    /// <response code="201">Returns "Created" with the created product</response>
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        product = await products.CreateAsync(product.Name, product.Description);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    /// <summary>
    /// Edits a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/products/{id}
    ///     {
    ///         "id": {id}
    ///         "name": "New Candy",
    ///         "description": "Chocolate"
    ///     }
    /// </remarks>
    /// <response code="204">Returns "No Content" on success</response>
    /// <response code="400">Returns "Bad Request" when an invalid request is sent</response>
    /// <response code="404">Returns "Not Found" when product with the given id doesn't exist</response>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        try
        {
            await products.EditAsync(id, product);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Edits a product partially.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH /api/products/{id}
    ///     {
    ///         "name": "New Candy"
    ///     }
    /// </remarks>
    /// <response code="204">Returns "No Content" on success</response>
    /// <response code="404">Returns "Not Found" when product with the given id doesn't exist</response>
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PatchProduct(int id, Product product)
    {
        try
        {
            await products.EditPartiallyAsync(id, product);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }

        return NoContent();
    }


    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/products/{id}
    ///     {
    ///
    ///     }
    /// </remarks>
    /// <response code="200">Returns "OK" with the deleted product</response>
    /// <response code="404">Returns "Not Found" when product with the given id doesn't exist</response>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        try
        {
            return await products.DeleteAsync(id);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}