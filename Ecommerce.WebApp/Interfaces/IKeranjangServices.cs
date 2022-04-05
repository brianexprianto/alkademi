namespace Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas.Entities;
using Ecommerce.WebApp.ViewModels;
public interface IKeranjangServices : ICrudServices<Keranjang>
{
      Task<List<KeranjangViewModel>> Get(int idCustomer);
      Task Clear(int idCustomer);  
}