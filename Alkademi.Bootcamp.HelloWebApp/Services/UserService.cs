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
                new User(1, "Brina", "brian"),
                new User(2, "Brian 1", "alkademi"),
                new User(3, "Brian 2", "exprianto"),
                new User(4, "Brian 2", "alkademi"),
                
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