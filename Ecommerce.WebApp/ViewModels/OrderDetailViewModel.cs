namespace Ecommerce.WebApp.ViewModels;
public class OrderDetailViewModel {
    public int Id { get; set; }
    public string Produk { get; set; }
    public decimal Harga {get;set;}
    public int Qty {get;set;}
    public decimal Subtotal {get;set;}
}