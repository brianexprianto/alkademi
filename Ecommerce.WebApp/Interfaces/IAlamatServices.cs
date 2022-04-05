namespace Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas.Entities;
using Ecommerce.WebApp.ViewModels;
public interface IAlamatServices : ICrudServices<Alamat>
{
    Task<List<Alamat>> GetAll(int idCustomer);
}