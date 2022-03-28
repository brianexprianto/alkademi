using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class KategoriProduk
    {
        public KategoriProduk()
        {
            ProdukKategoris = new HashSet<ProdukKategori>();
        }

        public int IdKategori { get; set; }
        public string NamaKategori { get; set; } = null!;
        public string Deskripsi { get; set; } = null!;
        public string Icon { get; set; } = null!;

        public virtual ICollection<ProdukKategori> ProdukKategoris { get; set; }
    }
}
