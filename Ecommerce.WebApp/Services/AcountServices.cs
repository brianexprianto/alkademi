using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.ViewModels;

namespace Ecommerce.WebApp.Services;
public class AccountServices : BaseDbServices, IAccountServices
{
    public AccountServices(EcommerceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Admin> Login(string username, string password)
    {
        var result = await DbContext.Admins.FirstOrDefaultAsync(x=>x.Username == username && x.Password == password);

        return result;
    }

    public async Task<Customer> LoginCustomer(string username, string password)
    {
        return await DbContext.Customers.FirstOrDefaultAsync(x=>x.Username == username && x.Password == password);
    }

    public async Task<List<Tuple<int, string>>> GetAlamat(int idCustomer){
        return await DbContext.Alamats.Where(x=>x.IdCustomer == idCustomer)
        .Select(x => new Tuple<int, string>(x.IdAlamat, x.DetailAlamat))
        .ToListAsync();
    }

    public async Task<Customer> Register(RegisterViewModel request){
        //check username sudah ada atau belum di db
        if(await DbContext.Customers.AnyAsync(x=>x.Username == request.Username)){
            throw new InvalidOperationException($"{request.Username} already exist");
        }

        //check email exist or not
        if(await DbContext.Customers.AnyAsync(x=>x.Email == request.Email)){
            throw new InvalidOperationException($"{request.Email} already exist");
        }
        
        //check nohp exist or not
        if(await DbContext.Customers.AnyAsync(x=>x.NoHp == request.NoHp)){
            throw new InvalidOperationException($"{request.NoHp} already exist");
        }

        var newCustomer = request.ConvertToDataModel();
        await DbContext.Customers.AddAsync(newCustomer);

        await DbContext.SaveChangesAsync();

        return newCustomer; 
    }

    // public async Task<Admin> Add(Admin obj)
    // {
    //     if(await DbContext.Admins.AnyAsync(x=>x.IdAdmin == obj.IdAdmin)){
    //         throw new InvalidOperationException($"Produk with ID {obj.IdAdmin} is already exist");
    //     }

    //     await DbContext.AddAsync(obj);
    //     await DbContext.SaveChangesAsync();
        
    //     return obj;
    // }
}