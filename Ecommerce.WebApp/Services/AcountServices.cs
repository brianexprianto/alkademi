using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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