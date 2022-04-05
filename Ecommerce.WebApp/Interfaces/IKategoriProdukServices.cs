namespace Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas.Entities;
public interface IKategoriProdukServices 
{
    Task<int[]> GetKategoriIds (int idProduk);
    Task Remove(int idProduk, int idKategori);
}