using System.ComponentModel.DataAnnotations;

namespace Broadvoice_Webapi.Models;
public class SalesPerson
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}