using Broadvoice_Webapi.Models;
namespace Broadvoice_Webapi.DatabaseConnection;

public interface IDBConnection {

    public IEnumerable<Sales> SelectSales(string salesperson, 
                                int productCode, 
                                string useremail, 
                                string city, 
                                string state,
                                DateTime startDate,
                                DateTime endDate);
}