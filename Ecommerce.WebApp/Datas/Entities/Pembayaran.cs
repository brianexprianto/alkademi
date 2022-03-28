using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Pembayaran
    {
        public int IdPembayaran { get; set; }
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public string MetodePembayaran { get; set; } = null!;
        public decimal TotalBayar { get; set; }
        public DateOnly TglBayar { get; set; }
        public decimal Pajak { get; set; }
        public string Tujuan { get; set; } = null!;

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual Orderr IdOrderNavigation { get; set; } = null!;
    }
}
