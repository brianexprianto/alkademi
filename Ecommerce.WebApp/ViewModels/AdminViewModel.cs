using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels
{
    public class AdminViewModel
    {
        public AdminViewModel()
        {  
            NamaAdmin = string.Empty;
            NoHp = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }

        public AdminViewModel(Admin item) {
            IdAdmin = item.IdAdmin;
            NamaAdmin = item.NamaAdmin;
            NoHp = item.NoHp;
            Username = item.Username;
            Password = item.Password;
        }

        public int IdAdmin { get; set; }
        [Required]
        public string NamaAdmin { get; set; }
        public string NoHp { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Admin ConvertToDbModel(){
            return new Admin {
                IdAdmin = this.IdAdmin,
                NamaAdmin = this.NamaAdmin,
                NoHp = this.NoHp,
                Username = this.Username,
                Password = this.Password,
            };
        }
    }
}