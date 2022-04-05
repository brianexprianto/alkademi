using Ecommerce.WebApp.Datas.Entities;
namespace Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.ViewModels;
public interface IAccountServices
{
    Task<Admin> Login(string username, string password); 
    
    Task<Customer> LoginCustomer(string username, string password);
    Task<Customer> Register(RegisterViewModel request);     
    
    Task<List<Tuple<int, string>>> GetAlamat(int idCustomer); 
}