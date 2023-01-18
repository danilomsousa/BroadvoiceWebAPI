using System.ComponentModel.DataAnnotations;

namespace Broadvoice_Webapi.Models;
public class Location
{
    [Key]
    public int Id { get; set; }    
    public string City { get; set; }
    public string State { get; set; }
}