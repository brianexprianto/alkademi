using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Datas.Entities
{
    public partial class StatusOrder
    {
        public int IdStatus { get; set; }
        public string Nama { get; set; } = null!;
        public string Deskripsi { get; set; } = null!;
    }
}
