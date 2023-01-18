using System.ComponentModel.DataAnnotations;

namespace Broadvoice_Webapi.Models;
public class Sales
{
    [Key]
    public int Id { get; set; }    
    public SalesPerson SalesPerson { get; set; }
    public Customer Customer { get; set; }
    public Location Location { get; set; }  
    public ICollection<Product> Products  { get; set; }  
    public DateTime SalesDate { get; set; }

}