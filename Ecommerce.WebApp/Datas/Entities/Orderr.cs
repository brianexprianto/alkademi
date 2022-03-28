using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Orderr
    {
        public Orderr()
        {
            Pembayarans = new HashSet<Pembayaran>();
            Pengirimen = new HashSet<Pengiriman>();
        }

        public int IdOrder { get; set; }
        public int IdKeranjang { get; set; }
        public int TglTransaksi { get; set; }
        public decimal JlhBayar { get; set; }
        public int IdAlamat { get; set; }
        public int IdCustomer { get; set; }
        public string Status { get; set; } = null!;
        public string Notes { get; set; } = null!;

        public virtual Alamat IdAlamatNavigation { get; set; } = null!;
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual Keranjang IdKeranjangNavigation { get; set; } = null!;
        public virtual ICollection<Pembayaran> Pembayarans { get; set; }
        public virtual ICollection<Pengiriman> Pengirimen { get; set; }
    }
}
