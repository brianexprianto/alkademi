using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.WebApp.Interfaces;


namespace Ecommerce.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProdukServices _produkServices;

    public HomeController(ILogger<HomeController> logger, IProdukServices produkServices)
    {
        _logger = logger;
        _produkServices = produkServices;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (HttpContext.User == null || HttpContext.User.Identity == null)
        {
            ViewBag.IsLogged = false;
        }
        else
        {
            ViewBag.IsLogged = HttpContext.User.Identity.IsAuthenticated;
        }

        base.OnActionExecuted(context);
    }

    public async Task<IActionResult> Index(int? page, int? pageCount)
    {
        var viewModels = new List<ProdukViewModel>();

        int limit = 2;
        if (pageCount != null)
        {
            limit = pageCount.Value;
        }

        int offset = 0;
        if (page == null)
        {
            offset = 0;
        }
        else
        {
            offset = (page.Value - 1) * limit;
        }

        var dbResult = await _produkServices.Get(limit, offset, string.Empty);

        if (dbResult == null || !dbResult.Any())
        {
            return RedirectToAction(nameof(Index), new
            {
                page = page > 1 ? page - 1 : 1,
                pageCount = pageCount
            });
        }


        for (int i = 0; i < dbResult.Count; i++)
        {
            viewModels.Add(new ProdukViewModel
            {
                IdProduk = dbResult[i].IdProduk,
                NamaProduk = dbResult[i].NamaProduk,
                Gambar = dbResult[i].Gambar,
                Harga = dbResult[i].Harga,
                Kategories = dbResult[i].ProdukKategoris.Select(x => new KategoriViewModel
                {
                    IdKategori = x.IdKategori,
                    NamaKategori = x.IdKategoriNavigation.NamaKategori,
                    Icon = x.IdKategoriNavigation.Icon
                }).ToList()
            });
        }
        
        ViewBag.HalamanSekarang = page ?? 1;

        return View(viewModels);
    }

    public async Task<IActionResult> Produk(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produk = await _produkServices.Get(id.Value);

        if (produk == null)
        {
            return NotFound();
        }

        return View(new ProdukDetailViewModel()
        {
            IdProduk = produk.IdProduk,
            NamaProduk = produk.NamaProduk,
            Deskripsi = produk.Deskripsi,
            Harga = produk.Harga,
            Gambar = produk.Gambar,
            Stok = 100,
            Terjual = 10
        });
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Denied()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}