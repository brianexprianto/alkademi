namespace Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas.Entities;
using Ecommerce.WebApp.ViewModels;

public interface IOrderServices
{
    Task<Orderr> Checkout(Orderr newOrder);  
    
    Task<List<OrderViewModel>> Get(int idCustomer);     
}