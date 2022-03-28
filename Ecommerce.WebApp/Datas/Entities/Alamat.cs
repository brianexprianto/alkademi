using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Alamat
    {
        public Alamat()
        {
            Orderrs = new HashSet<Orderr>();
            Pengirimen = new HashSet<Pengiriman>();
        }

        public int IdAlamat { get; set; }
        public int IdCustomer { get; set; }
        public string Kec { get; set; } = null!;
        public string Kel { get; set; } = null!;
        public string KabKota { get; set; } = null!;
        public string Prov { get; set; } = null!;
        public string DetailAlamat { get; set; } = null!;
        public string KodePos { get; set; } = null!;

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual ICollection<Orderr> Orderrs { get; set; }
        public virtual ICollection<Pengiriman> Pengirimen { get; set; }
    }
}
