using Ecommerce.WebApp.Datas.Entities;
namespace Ecommerce.WebApp.Interfaces;

public interface IAccountServices
{
    Task<Admin> Login(string username, string password);    
}