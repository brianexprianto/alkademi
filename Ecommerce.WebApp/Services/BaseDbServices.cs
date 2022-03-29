using Ecommerce.WebApp.Interfaces;
using Ecommerce.WebApp.Datas;
using Ecommerce.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Services;
public class BaseDbServices
{
    protected readonly EcommerceDbContext DbContext;
    public BaseDbServices(EcommerceDbContext dbContext)
    {
        DbContext = dbContext;
    }
}