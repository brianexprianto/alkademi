using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public interface IFileUserService
    {
        Task<List<UserViewModel>> Read();
        Task Write(UserViewModel request);
    }
}
