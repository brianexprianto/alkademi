using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public interface IUserService
    {
        List<UserViewModel> GetUsers();
        int Add(UserViewModel request);
    }
}