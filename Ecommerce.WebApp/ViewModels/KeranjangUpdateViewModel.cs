using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels;
public class KeranjangUpdateViewModel
{
    public KeranjangUpdateViewModel()
    {
    }

    [Required]
    public int IdKeranjang { get; set; }
    [Required]
    public int JlhBarang { get; set; }
}