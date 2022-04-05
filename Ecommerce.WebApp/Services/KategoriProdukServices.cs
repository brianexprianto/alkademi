using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Services;
public class KategoriProdukServices : BaseDbServices, IKategoriProdukServices
{
    public KategoriProdukServices (EcommerceDbContext dbContext) : base (dbContext){

    }

    public async Task<int[]> GetKategoriIds (int idProduk){
        var result = await DbContext.ProdukKategoris
        .Where(x=>x.IdProduk == idProduk)
        .Select(x=>x.IdKategori)
        .Distinct()
        .ToArrayAsync();

        return result;

    }

    public async Task Remove(int idProduk, int idKategori)
    {
        var item = await DbContext.ProdukKategoris.FirstOrDefaultAsync(x => x.IdProduk == idProduk && x.IdKategori == idKategori);
        
        if(item == null)
        {
            return;
        }
        
        DbContext.ProdukKategoris.Remove(item);

        await DbContext.SaveChangesAsync();
    }
}