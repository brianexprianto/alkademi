﻿using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class ProdukKategori
    {
        public int IdProdukKategori { get; set; }
        public int IdProduk { get; set; }
        public int IdKategori { get; set; }

        public virtual KategoriProduk IdKategoriNavigation { get; set; } = null!;
        public virtual Produk IdProdukNavigation { get; set; } = null!;
    }
}
