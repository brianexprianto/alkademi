namespace Ecommerce.WebApp.ViewModels;
public class OrderViewModel {
    public OrderViewModel()
    {
        Details = new List<OrderDetailViewModel>();
    }
    public int IdOrder { get; set; }
    public DateOnly TglTransaksi { get; set; }
    public int TotalQty { get {
        return (Details == null || !Details.Any()) ? 0 : Details.Sum(x=>x.Qty);
    }}
    public decimal JlhBayar { get; set; }
    public string Status { get; set; }

    public List<OrderDetailViewModel> Details { get; set; }
}