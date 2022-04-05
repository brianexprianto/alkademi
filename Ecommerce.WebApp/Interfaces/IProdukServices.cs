namespace Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas.Entities;
public interface IProdukServices : ICrudServices<Produk>
{
    Task<Produk> Add(Produk obj, int idKategori);
    
}