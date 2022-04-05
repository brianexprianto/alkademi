using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.ViewModels;
using System.Linq;

namespace Ecommerce.WebApp.Services;
public class KeranjangServices : BaseDbServices, IKeranjangServices
{
    private readonly IProdukServices _produkServices;
    public KeranjangServices(EcommerceDbContext dbContext, IProdukServices produkServices
    ) : base(dbContext)
    {
        _produkServices = produkServices;
    }

    public async Task<Keranjang> Add(Keranjang obj)
    {
        if(await DbContext.Keranjangs.AnyAsync(x=>x.IdProduk == obj.IdProduk && x.IdCustomer == obj.IdCustomer))
        {
            return obj;
        }

        //get data produk
        var produk = await _produkServices.Get(obj.IdProduk);

        if(produk == null)
        {
            throw new InvalidOperationException("Produk tidak ditemukan");
        }

        if(obj.JlhBarang < 1) 
        {
            obj.JlhBarang = 1;
        }

        
        obj.Subtotal = produk.Harga * obj.JlhBarang;

        await DbContext.AddAsync(obj);
        await DbContext.SaveChangesAsync();

        return obj;
    }

    public async Task Clear(int idCustomer)
    {
        DbContext.RemoveRange(DbContext.Keranjangs.Where(x=>x.IdCustomer == idCustomer));
        await DbContext.SaveChangesAsync();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Keranjang>> Get(int limit, int offset, string keyword)
    {
        throw new NotImplementedException();
    }

    public Task<Keranjang?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Keranjang?> Get(Expression<Func<Keranjang, bool>> func)
    {
        throw new NotImplementedException();
    }

    public Task<List<Keranjang>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Keranjang> Update(Keranjang obj)
    {
        throw new NotImplementedException();
    }

    async Task<List<KeranjangViewModel>> IKeranjangServices.Get(int idCustomer)
    {
        var result = await (from a in DbContext.Keranjangs
        join b in DbContext.Produks on a.IdProduk equals b.IdProduk
        where a.IdCustomer == idCustomer
        select new KeranjangViewModel 
        {
            IdKeranjang = a.IdKeranjang,
            IdCustomer = a.IdCustomer,
            IdProduk = a.IdProduk,
            HargaBarang = b.Harga,
            Image = b.Gambar,
            JlhBarang  = a.JlhBarang,
            Subtotal  = a.Subtotal,
            NamaProduk = b.NamaProduk
        }).ToListAsync();

        return result;
    }
}