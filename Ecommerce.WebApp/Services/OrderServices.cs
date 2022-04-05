using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.ViewModels;

namespace Ecommerce.WebApp.Services;
public class OrderServices : BaseDbServices, IOrderServices
{
    public OrderServices(EcommerceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Orderr> Checkout(Orderr newOrder)
    {
        await DbContext.AddAsync(newOrder);
        await DbContext.SaveChangesAsync();

        return newOrder;
    }

    public async Task<List<OrderViewModel>> Get(int idCustomer)
    {
        var result = await (from a in DbContext.Orderrs
        join b in DbContext.StatusOrders on a.IdStatus equals b.IdStatus
        join alamat in DbContext.Alamats on a.IdAlamat equals alamat.IdAlamat
        select new OrderViewModel
        {
            IdOrder = a.IdOrder,
            Status = b.Nama,
            TglTransaksi = a.TglTransaksi,
            JlhBayar = a.JlhBayar,
            Details = (from c in DbContext.DetailOrders
                join d in DbContext.Produks on c.IdProduk equals d.IdProduk
                where c.IdOrder == a.IdOrder
                select new OrderDetailViewModel
                {
                    Id = c.Id,
                    Produk = d.NamaProduk,
                    Harga = c.Harga,
                    Qty = c.JlhBarang,
                    Subtotal = c.Subtotal
                }).ToList()
        }).ToListAsync();

        return result;
    }
} 