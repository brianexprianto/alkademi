using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Pengiriman
    {
        public int IdPengiriman { get; set; }
        public int IdOrder { get; set; }
        public string Kurir { get; set; } = null!;
        public decimal Ongkir { get; set; }
        public int IdAlamat { get; set; }
        public string Status { get; set; } = null!;

        public virtual Alamat IdAlamatNavigation { get; set; } = null!;
        public virtual Orderr IdOrderNavigation { get; set; } = null!;
    }
}
