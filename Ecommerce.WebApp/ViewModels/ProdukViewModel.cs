using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels
{
    public class ProdukViewModel
    {
        public ProdukViewModel()
        {
            Kategories = new List<KategoriViewModel>();
        }
        
        public ProdukViewModel(Produk item){
            IdProduk = item.IdProduk;
            NamaProduk = item.NamaProduk;
            Deskripsi = item.Deskripsi;
            Harga = item.Harga;
            Stok = 100;
            IdKategori = Array.Empty<int>();
            Kategories = new List<KategoriViewModel>();
        }

        public int IdProduk { get; set; }
        [Required]
        public string NamaProduk { get; set; }
        public string Deskripsi { get; set; }
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public string? Gambar { get; set; }
        public string GambarSrc {
            get {
                return (string.IsNullOrEmpty(Gambar) ? "images/default.png" : Gambar );
            }
        }
        public IFormFile? GambarFile { get; set; }

        public int[] IdKategori { get; set; }
        public List<KategoriViewModel> Kategories { get; set; }
        
        
        

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