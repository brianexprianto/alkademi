namespace Ecommerce.WebApp.ViewModels;
public class CheckoutViewModel
{
    public int[] Id { get; set; }
    public int[] Qty { get; set; }
    public int Alamat { get; set; }
    public string Action { get; set; }
    public string? Notes { get; set; }
}