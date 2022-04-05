using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.ViewModels;

namespace Ecommerce.WebApp.Services;
public class AlamatServices : BaseDbServices, IAlamatServices
{
    public AlamatServices(EcommerceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Alamat> Add(Alamat obj)
    {
        if(await DbContext.Alamats.AnyAsync(x=>x.IdAlamat == obj.IdAlamat)){
            throw new InvalidOperationException($"Alamat with ID {obj.IdAlamat} is already exist");
        }

        await DbContext.AddAsync(obj);
        await DbContext.SaveChangesAsync();

        return obj;
    }

    public async Task<Alamat> Add(Alamat obj, int idAlamat)
    {
        if(await DbContext.Alamats.AnyAsync(x=>x.IdAlamat == obj.IdAlamat)){
            throw new InvalidOperationException($"Alamat with ID {obj.IdAlamat} is already exist");
        }

        await DbContext.AddAsync(obj);
        await DbContext.SaveChangesAsync();

        DbContext.Alamats.Add(new Alamat{
            IdAlamat = obj.IdAlamat,
            IdCustomer = obj.IdCustomer,
            DetailAlamat = obj.DetailAlamat,
            Kec = obj.Kec,
            Kel = obj.Kel,
            KabKota = obj.KabKota,
            Prov = obj.Prov,
            KodePos = obj.KodePos,
            IdCustomerNavigation = obj.IdCustomerNavigation
        });


        return obj;
    }




    public async Task<List<Alamat>> Get(int limit, int offset, string keyword)
    {
        if(string.IsNullOrEmpty(keyword)){
            keyword = "";
        }

        return await DbContext.Alamats
        .Skip(offset)
        .Take(limit).ToListAsync();
    }

    public async Task<Alamat?> Get(int idAlamat)
    {
        var result = await DbContext.Alamats.FirstOrDefaultAsync(x=>x.IdAlamat == idAlamat);

        if(result == null)
        {
            throw new InvalidOperationException($"alamat with ID {idAlamat} doesn't exist");
        }

        return result;
    }

    public Task<Alamat?> Get(Expression<Func<Alamat, bool>> func)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Alamat>> GetAll()
    {
        return await DbContext.Alamats.ToListAsync();
    }

    public async Task<List<Alamat>> GetAll(int idCustomer)
    {
        return await DbContext.Alamats.Where(x => x.IdCustomer == idCustomer).ToListAsync();
    }
    
    
    public async Task<bool> Delete(int id)
    {
        var alamat = await DbContext.Alamats.FirstOrDefaultAsync(x=>x.IdAlamat == id);

        if(alamat == null) {
            throw new InvalidOperationException($"Alamat with ID {id} doesn't exist");
        }

        DbContext.Alamats.RemoveRange(DbContext.Alamats.Where(x=>x.IdAlamat == id));
        
        DbContext.Remove(alamat);
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Alamat> Update(Alamat obj)
    {
        if(obj == null)
        {
            throw new ArgumentNullException("alamat cannot be null");
        }

        var alamat = await DbContext.Alamats.FirstOrDefaultAsync(x=>x.IdAlamat == obj.IdAlamat);

        if(alamat == null) {
            throw new InvalidOperationException($"Alamat with ID {obj.IdAlamat} doesn't exist in database");
        }



        alamat.DetailAlamat= obj.DetailAlamat;
        alamat.Kec = obj.Kec;
        alamat.Kel = obj.Kel;
        alamat.KabKota = obj.KabKota;
        alamat.Prov = obj.Prov;
        alamat.KodePos = obj.KodePos;
        
        DbContext.Update(alamat);
        await DbContext.SaveChangesAsync();

        return alamat;
    }
}