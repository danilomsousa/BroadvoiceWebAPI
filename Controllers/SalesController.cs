using Microsoft.AspNetCore.Mvc;
using Broadvoice_Webapi.Models;

namespace Broadvoice_Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController : ControllerBase
{

    private readonly ILogger<SalesController> _logger;

    public SalesController(ILogger<SalesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSales")]
    public IEnumerable<Sales> Get(string salesperson = "", 
                                int productCode = 0, 
                                string useremail = "", 
                                string city = "", 
                                string state = "",
                                DateTime startDate = new DateTime(),
                                DateTime endDate = new DateTime())
    {
        using var db = new SalesContext();        
        FakeData.FakeData.generateData(db);

        if(endDate == DateTime.MinValue) endDate = DateTime.MaxValue;
        Console.WriteLine($"start {startDate} end {endDate}");        

        return db.Sales.Where(sales => sales.SalesPerson.Name == (salesperson == "" ? sales.SalesPerson.Name : salesperson))
        .Where(sales => sales.Products.Where(product => product.Code == (productCode == 0 ? product.Code : productCode)).Count() > 0)
        .Where(sales => sales.Customer.Email == (useremail == "" ? sales.Customer.Email : useremail))
        .Where(sales => sales.Location.City == (city == "" ? sales.Location.City : city))
        .Where(sales => sales.Location.State == (state == "" ? sales.Location.State : state))
        .Where(sales => sales.SalesDate >= startDate && sales.SalesDate <= endDate)
        .ToArray();
    }
}
