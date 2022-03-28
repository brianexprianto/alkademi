using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; } = null!;
        public string NoHp { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
