namespace Alkademi.Bootcamp.HelloWebApp.Models;

public class User
{
    public int Id {get;set;}
    public string Username {get;set;}
    public string Password{get;set;}
    public string ProfileImages {get;set;}
    public int Subscribers {get; set;}
    public string AboutUser {get;set;}

    
    public User(int id, string username, string password){
        if(id == 0){
            Id = new Random().Next();
        } else{
            Id = id;
        }
        Username = username;
        Password = password;
    }
}
