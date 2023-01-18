using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Broadvoice_Webapi.Models;

namespace Broadvoice_Webapi.DatabaseConnection;
public class SalesContext : DbContext, IDBConnection
{
    public DbSet<SalesPerson> SalesPerson { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Sales> Sales { get; set; }

    public String DbPath;
    public SalesContext()
    {        
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "sales.db");
        FakeData.FakeData.generateData(this);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public IEnumerable<Sales> SelectSales(string salesperson, int productCode, string useremail, string city, string state, DateTime startDate, DateTime endDate)
    {
        if(endDate == DateTime.MinValue) endDate = DateTime.MaxValue;        

        try{
            return Sales.Where(sales => sales.SalesPerson.Name == (salesperson == "" ? sales.SalesPerson.Name : salesperson))
            .Where(sales => sales.Products.Where(product => product.Code == (productCode == 0 ? product.Code : productCode)).Count() > 0)
            .Where(sales => sales.Customer.Email == (useremail == "" ? sales.Customer.Email : useremail))
            .Where(sales => sales.Location.City == (city == "" ? sales.Location.City : city))
            .Where(sales => sales.Location.State == (state == "" ? sales.Location.State : state))
            .Where(sales => sales.SalesDate >= startDate && sales.SalesDate <= endDate)
            .ToArray();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
            return null;
        }
    }
}
