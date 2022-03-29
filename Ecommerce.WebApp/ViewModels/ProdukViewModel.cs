using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels
{
    public class ProdukViewModel
    {
        public ProdukViewModel()
        {
            
        }
        
        public ProdukViewModel(int idProduk, string namaProduk, string deskripsi, decimal harga){
            IdProduk = idProduk;
            NamaProduk = namaProduk;
            Deskripsi = deskripsi;
            Harga = harga;
            Stok = 100;
        }

        public int IdProduk { get; set; }
        [Required]
        public string NamaProduk { get; set; }
        public string Deskripsi { get; set; }
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public string? Gambar { get; set; }

        public int IdKategori {get;set;}
        public string? NamaKategori {get;set;}
        
        

        public Produk ConvertToDbModel(){
            return new Produk() {
                IdProduk = this.IdProduk,
                NamaProduk = this.NamaProduk,
                Deskripsi = this.Deskripsi,
                Harga = this.Harga,
                Stok = this.Stok,
                Gambar = this.Gambar ?? string.Empty,
            };
        }
    }
}