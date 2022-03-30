using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels
{
    public class KategoriViewModel
    {
        public KategoriViewModel()
        {
            NamaKategori = string.Empty;
            Deskripsi = string.Empty;
            Icon = string.Empty;
        }

        public KategoriViewModel(KategoriProduk item){
            IdKategori = item.IdKategori;
            NamaKategori = item.NamaKategori;
            Deskripsi = item.Deskripsi;
            Icon = item.Icon;
        }
        public int IdKategori { get; set; }
        [Required]
        public string NamaKategori { get; set; }
        public string Deskripsi { get; set; }
        public string Icon { get; set; }
        
    
        public IFormFile? IconFile { get; set; }

        public KategoriProduk ConvertToDbModel(){
            return new KategoriProduk {
                IdKategori = this.IdKategori,
                NamaKategori = this.NamaKategori,
                Deskripsi = this.Deskripsi,
                Icon = this.Icon,
            };
        }
        
    }
}