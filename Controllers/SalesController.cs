using Microsoft.AspNetCore.Mvc;
using Broadvoice_Webapi.Models;
using Broadvoice_Webapi.DatabaseConnection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Broadvoice_Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController : ControllerBase
{

    private readonly ILogger<SalesController> _logger;
    private readonly ApplicationDbContext _context;

    public SalesController(ILogger<SalesController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetSales")]
    public IActionResult Get(string salesperson = "", 
                                int productCode = 0, 
                                string useremail = "", 
                                string city = "", 
                                string state = "",
                                DateTime startDate = new DateTime(),
                                DateTime endDate = new DateTime())
    {
        IDBConnection connection = new SalesContext();   
        var todo = connection.SelectSales(salesperson,productCode,useremail,city,state,startDate,endDate);

        if (todo is null)
        {
            return NotFound();
        }   

        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
            
        return Ok(JsonSerializer.Serialize(todo, 
                                        options));
        
    }
}
