using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public class UserService : IUserService
    {
        List<User> _users;
        public UserService()
        {
            _users = new List<User>
            {
                new User(1, "Title", "Bootcamp alkademi"),
                new User(2, "Title 1", "Bootcamp alkademi"),
                new User(3, "Title 2", "Bootcamp alkademi"),
                new User(4, "Title 2", "Bootcamp alkademi"),
                
            };
        }
        public int Add(UserViewModel request)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetUsers()
        {
            List<UserViewModel> userViewModel = new List<UserViewModel>();

            foreach (var item in _users)
            {
                userViewModel.Add(new UserViewModel(item.Id, item.Username, item.Password));
            }

            return userViewModel;
        }
    }
}