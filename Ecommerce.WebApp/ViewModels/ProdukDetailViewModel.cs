using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels;
public class ProdukDetailViewModel: ProdukViewModel
{
    public ProdukDetailViewModel()
    {
        Kategories = new List<KategoriViewModel>();
    }

    public ProdukDetailViewModel(int id, string nama, string deskripsi, decimal harga)
    {
        IdProduk = id;
        NamaProduk = nama;
        Harga = harga;
        Kategories = new List<KategoriViewModel>();
    }
    public string Deskripsi { get; set; }
    public int Stok { get; set; }
    public int Terjual { get; set; }
    public string Gambar {get;set;}
}