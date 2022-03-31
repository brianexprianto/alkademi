namespace Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas.Entities;
public interface IKategoriProdukServices 
{
    Task<int[]> GetKategoriIds (int idProduk);
}