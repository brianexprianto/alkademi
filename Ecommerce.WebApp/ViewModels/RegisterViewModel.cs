using System.ComponentModel.DataAnnotations;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.ViewModels;

public class RegisterViewModel
{
    public RegisterViewModel()
    {
        Username = string.Empty;
        Password = string.Empty;
    }
    public RegisterViewModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
    [Required]
    public string NamaCustomer { get; set; } = null!;
    [Required]
    public string NoHp { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    public Customer ConvertToDataModel() {
        return new Customer {
            NamaCustomer = this.NamaCustomer,
            NoHp = this.NoHp,
            Email = this.Email,
            Username = this.Username,
            Password = this.Password,
            ProfilePicture = string.Empty
        };
    }
}