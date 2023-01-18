using Broadvoice_Webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Broadvoice_Webapi.FakeData;
public static class FakeData{

    public static void generateData(DbContext db ){
        db.Database.EnsureDeleted();
        // Note: This sample requires the database to be created before running.       
        db.Database.EnsureCreated();
        SalesPerson sp = new SalesPerson { Name="Danilo Sousa", Email="teste@teste.com" };
        Customer cust = new Customer { Name="Bruna Sakaue", Email="bru@teste.com" };
        Location lc = new Location { City="New York", State="New York" };
        Product product = new Product { Code=123, Name="Ipad", Cost=100.99 };
        Product product2 = new Product { Code=124, Name="Ball", Cost=9.99 };
        List<Product> productsList = new List<Product>();
        productsList.Add(product);
        productsList.Add(product2);
        db.Add(sp);
        db.Add(cust);
        db.Add(lc);
        db.Add(product);
        db.Add(product2);
        db.SaveChanges();

        db.Add(new Sales{ SalesPerson=sp, Customer=cust, Location=lc, Products=productsList, SalesDate=DateTime.Today});
        db.SaveChanges();

        db.Add(new Sales{ SalesPerson=sp, Customer=cust, Location=lc, Products=productsList, SalesDate=DateTime.Today});
        db.SaveChanges();
        
        sp = new SalesPerson { Name="Roberto Carlos", Email="robert@teste.com" };
        cust = new Customer { Name="Cristiano Ronaldo", Email="cris@teste.com" };
        lc = new Location { City="Lisboa", State="Portugal" };

        db.Add(new Sales{ SalesPerson=sp, Customer=cust, Location=lc, Products=productsList.Where(product => product.Id == 1).ToList(), SalesDate=DateTime.Today});
        db.SaveChanges();
    }
}