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
            
            //todo.Select(sales => sales.SalesPerson)
        return Ok(JsonSerializer.Serialize(from sales in todo
                                            select new { SalesPersonName = sales.SalesPerson.Name, SalesPersonEmail = sales.SalesPerson.Email,
                                                    CustomerName = sales.Customer.Name, CustomerEmail = sales.Customer.Email,
                                                    SalesCity = sales.Location.City, SalesState = sales.Location.State,
                                                    ProductName = convertProductMetadata(sales.Products),
                                                    SalesDate=sales.SalesDate}, 
                                        options));
        
    }

    private IEnumerable<ProductMetadata> convertProductMetadata(IEnumerable<Product> productsList){
        List<ProductMetadata> productsMetadataList = new List<ProductMetadata>();
        foreach(Product p in productsList){
            productsMetadataList.Add(new ProductMetadata{Code = p.Code, Name = p.Name, Cost = p.Cost});
        }
        return productsMetadataList;
    }
}
