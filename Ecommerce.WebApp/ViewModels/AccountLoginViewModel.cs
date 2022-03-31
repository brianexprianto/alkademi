using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.ViewModels;

public class AccountLoginViewModel
{
    public AccountLoginViewModel()
    {
        Username = string.Empty;
        Password = string.Empty;
    }
    public AccountLoginViewModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public int IdAdmin {get;set;}
    public string NoHp {get;set;}
    public string NamaAdmin {get;set;}

    // public AccountLoginViewModel ConvertToDbModel(){
    //         return new AccountLoginViewModel {
    //             IdAdmin = this.IdAdmin,
    //             Username = this.Username,
    //             Password = this.Password,
    //             NoHp = this.NoHp,
    //             NamaAdmin = this.NamaAdmin,
    //         };
    //     }


} 