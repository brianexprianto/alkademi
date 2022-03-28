using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Alamats = new HashSet<Alamat>();
            Keranjangs = new HashSet<Keranjang>();
            Orderrs = new HashSet<Orderr>();
            Pembayarans = new HashSet<Pembayaran>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; } = null!;
        public string NoHp { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePicture { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<Alamat> Alamats { get; set; }
        public virtual ICollection<Keranjang> Keranjangs { get; set; }
        public virtual ICollection<Orderr> Orderrs { get; set; }
        public virtual ICollection<Pembayaran> Pembayarans { get; set; }
    }
}
