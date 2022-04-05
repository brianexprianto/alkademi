using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Orderr
    {
        public Orderr()
        {
            DetailOrders = new HashSet<DetailOrder>();
            Pembayarans = new HashSet<Pembayaran>();
            Pengirimen = new HashSet<Pengiriman>();
        }

        public int IdOrder { get; set; }
        public DateOnly TglTransaksi { get; set; }
        public decimal JlhBayar { get; set; }
        public int IdAlamat { get; set; }
        public int IdCustomer { get; set; }
        public int IdStatus { get; set; }
        public string Notes { get; set; } = null!;

        public virtual Alamat IdAlamatNavigation { get; set; } = null!;
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual ICollection<DetailOrder> DetailOrders { get; set; }
        public virtual ICollection<Pembayaran> Pembayarans { get; set; }
        public virtual ICollection<Pengiriman> Pengirimen { get; set; }
    }
}
