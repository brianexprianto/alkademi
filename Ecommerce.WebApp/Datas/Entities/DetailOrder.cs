using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class DetailOrder
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdProduk { get; set; }
        public decimal Harga { get; set; }
        public int JlhBarang { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Orderr IdOrderNavigation { get; set; } = null!;
        public virtual Produk IdProdukNavigation { get; set; } = null!;
    }
}
