using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Services;
public class KategoriServices : BaseDbServices, IKategoriServices
{
    public KategoriServices(EcommerceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<KategoriProduk> Add(KategoriProduk obj)
    {
        if(await DbContext.KategoriProduks.AnyAsync(x=>x.IdKategori == obj.IdKategori)){
            throw new InvalidOperationException($"Kategori with ID {obj.IdKategori} is already exist");
        }

        await DbContext.AddAsync(obj);
        await DbContext.SaveChangesAsync();

        return obj;
    }


    public async Task<List<KategoriProduk>> Get(int limit, int offset, string keyword)
    {
        if(string.IsNullOrEmpty(keyword)){
            keyword = "";
        }

        return await DbContext.KategoriProduks
        .Skip(offset)
        .Take(limit).ToListAsync();
    }

    public async Task<KategoriProduk?> Get(int idKategori)
    {
        var result = await DbContext.KategoriProduks.FirstOrDefaultAsync(x=>x.IdKategori == idKategori);

        if(result == null)
        {
            throw new InvalidOperationException($"Kategori with ID {idKategori} doesn't exist");
        }

        return result;
    }

    public Task<KategoriProduk?> Get(Expression<Func<KategoriProduk, bool>> func)
    {
        throw new NotImplementedException();
    }

    public async Task<List<KategoriProduk>> GetAll()
    {
        return await DbContext.KategoriProduks.ToListAsync();
    }
    
    public async Task<bool> Delete(int id)
    {
        var kategori = await DbContext.KategoriProduks.FirstOrDefaultAsync(x=>x.IdKategori == id);

        if(kategori == null) {
            throw new InvalidOperationException($"Kategori with ID {id} doesn't exist");
        }

        DbContext.ProdukKategoris.RemoveRange(DbContext.ProdukKategoris.Where(x=>x.IdKategori == id));
        
        DbContext.Remove(kategori);
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<KategoriProduk> Update(KategoriProduk obj)
    {
        if(obj == null)
        {
            throw new ArgumentNullException("Kategori cannot be null");
        }

        var kategori = await DbContext.KategoriProduks.FirstOrDefaultAsync(x=>x.IdKategori == obj.IdKategori);

        if(kategori == null) {
            throw new InvalidOperationException($"Kategori with ID {obj.IdKategori} doesn't exist in database");
        }

        kategori.NamaKategori = obj.NamaKategori;
        kategori.Deskripsi = obj.Deskripsi;
        kategori.Icon = obj.Icon;
        
        DbContext.Update(kategori);
        await DbContext.SaveChangesAsync();

        return kategori;
    }
}