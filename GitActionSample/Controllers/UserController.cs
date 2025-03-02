using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GitActionSample.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Customers = new[]
    {
        "Antony - 09", "Lio - 10", "Dame - 11", "Test - 11"
    };
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        return Ok(Customers.ToList());
    }
    
    [HttpGet("{customerName}")]
    public async Task<IActionResult> GetByName(string customerName)
    {
        var customer = Customers.FirstOrDefault(c => c.IndexOf(customerName, StringComparison.OrdinalIgnoreCase) >= 0);
        if (customer == null)
            return NotFound();
        return Ok(customer);
    }
}