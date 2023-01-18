using System.ComponentModel.DataAnnotations;

namespace Broadvoice_Webapi.Models;
public class Product
{
    [Key]
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }    
    public ICollection<Sales> Sales { get; set; }
}