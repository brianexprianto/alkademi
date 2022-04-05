using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels;
public class KeranjangViewModel
{
    public KeranjangViewModel()
    {
    }

    public int IdKeranjang { get; set; }
    public int IdProduk { get; set; }
    public string Image { get; set; }
    public string NamaProduk { get; set; }
    public int IdCustomer { get; set; }
    public int JlhBarang { get; set; }
    public decimal Subtotal { get; set; }
    public decimal HargaBarang { get; set; }
    public int IdAlamat {get;set;}

   
}