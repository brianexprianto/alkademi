using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Produk
    {
        public Produk()
        {
            ProdukKategoris = new HashSet<ProdukKategori>();
        }

        public int IdProduk { get; set; }
        public string NamaProduk { get; set; } = null!;
        public string Deskripsi { get; set; } = null!;
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public string Gambar { get; set; } = null!;

        public virtual ICollection<ProdukKategori> ProdukKategoris { get; set; }
    }
}
