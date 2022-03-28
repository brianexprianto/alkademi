using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Keranjang
    {
        public Keranjang()
        {
            Orderrs = new HashSet<Orderr>();
        }

        public int IdKeranjang { get; set; }
        public int IdCustomer { get; set; }
        public int JlhBarang { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual ICollection<Orderr> Orderrs { get; set; }
    }
}
