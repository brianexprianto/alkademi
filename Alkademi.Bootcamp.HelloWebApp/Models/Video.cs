namespace Alkademi.Bootcamp.HelloWebApp.Models;

public class Video
{
    public int Id {get;set;}
    public string Title {get;set;}
    public string Desc {get;set;}
    public string TotalLike {get;set;}
    public string LinkVideo {get;set;}

    public User User{get;set;}

    public Video(int id, string title, string desc)
    {
        if(id == 0){
            Id = new Random().Next();
        } else{
            Id = id;
        }
        Id = id;
        Title = title;
        Desc = desc;
    }

    public void PostBy (User user){
        User = user;
    }
}
