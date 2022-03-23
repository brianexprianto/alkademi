using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Alkademi.Bootcamp.HelloWebApp.Models;


namespace Alkademi.Bootcamp.HelloWebApp.Controllers;

public class HomeController : Controller
{
    List<Video> _listvideo = new List<Video>();


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _listvideo = new List<Video>(){
            new Video(1,"Real Madrid 0-4 Barcelona | LaLiga 21/22 Match Highlights","Real Madrid 0-4 Barcelona, Senin, 21 Maret 2022 Performa impresif Barca di bawah XAVI terus berlanjut. Kali ini BARCELONA hancurkan REAL MADRID 4-0 dalam laga bertajuk ElClásico di Santiago...")
            {
                LinkVideo = "https://www.youtube.com/embed/qkQDvE9AhKk",
                User = new User(1, "beIN Sports Indonesia","https://yt3.ggpht.com/ytc/AKedOLQdDxlp_VQnfiCT5kcR13h8KyOjG2_tRvm3zYa58w=s48-c-k-c0x00ffffff-no-rj"),
            },
            new Video(2,"#MotoGP Race Build up at the #IndonesianGP 🇮🇩","Unpredictable weather ✅ Reduced race times ✅ The stage is set for an almighty afternoon at the #IndonesianGP 🇮🇩 Join us as we build up to the first #MotoGP race in Indonesia for...")
            {
                LinkVideo = "https://www.youtube.com/embed/AbBDyWWHUOg",
                User = new User(2, "MotoGP","https://yt3.ggpht.com/Ae6_xX9VoZWUUBqHInTaJ8vCzGHuYPZ4W-rNy1Q0SOjwEWzuNZoVgPDGASPYi7WpfNGJxOapEQ=s48-c-k-c0x00ffffff-no-rj"),
            },
            new Video(3,"Red Velvet 레드벨벳 'Feel My Rhythm' MV","Red Velvet's mini album 'The ReVe Festival 2022 - Feel My Rhythm' is out! Listen and download on your favorite platform: https://smarturl.it/RV_FeelMyRhythm [Tracklist] 01 Feel My Rhythm...")
            {
                LinkVideo = "https://www.youtube.com/embed/R9At2ICm4LQ",
                User = new User(3, "SMTOWN","https://yt3.ggpht.com/_1Z4I2qpWaCN9g3BcDd3cVA9MDHOG43lE1YNWDNkKro49haGxkjwuFK-I8faWTKM6Jle9qb4ag=s48-c-k-c0x00ffffff-no-rj"),
            },
            new Video(4,"Kanda Brothers - Go (Official Music Video)","GO – a Story About Fuji Tidak semua yang terlihat di luar mencerminkan apa yang sebenarnya terjadi di dalam. Apa yang cuma kita liat di social media, belum tentu mencerminkan apa yang...")
            {
                LinkVideo = "https://www.youtube.com/embed/f2h_z-ZejzY",
                User = new User(4, "Kanda Brothers","https://yt3.ggpht.com/zRrsN-y_InHXUa4qKLfG0PuQcZYegWXbFc8oRvVpb5ikqwaoOOeuKtnaDY74tPg9c_PcQBxMu4c=s48-c-k-c0x00ffffff-no-nd-rj"),
            },
            new Video(5,"BANYAK NANGIS SELAMA KEHAMILAN | RIA RICIS #OSHICIS","#OSHICIS . . Sahabat yang mau melihat ceramah Umma Oki Setiana Dewi bisa di . For da’wah channel youtube : https://www.youtube.com/channel/UC5NfojASxlqmZ8vq0Db5mBg instagram : Jangan...")
            {
                LinkVideo = "https://www.youtube.com/embed/JL7qn-4rUFU",
                User = new User(5, "Oki Setiana Dewi","https://yt3.ggpht.com/ytc/AKedOLR0iAEcSeW9ldvFaAkPbZkR4XfbRIVDogC2CuYUWA=s48-c-k-c0x00ffffff-no-rj"),
            },
        };
    }

    public IActionResult Index()
    {
        ViewData["ListVideo"] = _listvideo;
        ViewBag.ListVideo = _listvideo;
        return View(_listvideo);
    }

    [Route("home/detailvid/{title}")]
    public IActionResult DetailVid(string title)
    {
        //get data from list tweet by username
        var datas = _listvideo.Where(x=> x != null && x.Title != null && x.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

       return View(datas); 
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
