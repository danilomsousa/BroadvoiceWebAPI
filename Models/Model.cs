using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Broadvoice_Webapi.Models;
public class SalesContext : DbContext
{
    public DbSet<SalesPerson> SalesPerson { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Sales> Sales { get; set; }

    public string DbPath { get; }

    public SalesContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "sales.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
