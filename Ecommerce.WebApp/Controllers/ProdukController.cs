using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.WebApp.Controllers;

public class ProdukController : Controller
{
    private readonly IProdukServices _produkServices;
    private readonly IKategoriServices _kategoriServices;
    private readonly ILogger<ProdukController> _logger;

    public ProdukController(ILogger<ProdukController> logger, IProdukServices produkServices, IKategoriServices kategoriServices)
    {
        _logger = logger;
        _produkServices = produkServices;
        _kategoriServices = kategoriServices;
    }

    public async Task<IActionResult> Index()
    {
        var dbResult = await _produkServices.GetAll();

        var viewModels = new List<ProdukViewModel>();

        for (int i = 0; i < dbResult.Count; i++)
        {
            viewModels.Add(new ProdukViewModel{
                IdProduk = dbResult[i].IdProduk,
                NamaProduk = dbResult[i].NamaProduk,
                Deskripsi = dbResult[i].Deskripsi,
                Harga = dbResult[i].Harga,
                Stok = dbResult[i].Stok,
                Gambar = dbResult[i].Gambar,
            });
        }

        return View(viewModels);
    }

    private async Task SetKategoriDataSource()
    {
        var kategoriViewModels = await _kategoriServices.GetAll();

        ViewBag.KategoriDataSource = kategoriViewModels.Select(x => new SelectListItem
        {
            Value = x.IdKategori.ToString(),
            Text = x.NamaKategori,
            Selected = false
        }).ToList();
    }

    public async Task<IActionResult> Create() {
        await SetKategoriDataSource();
        return View(new ProdukViewModel());
    }

 [HttpPost]
    public async Task<IActionResult> Create(ProdukViewModel request) {
        if(!ModelState.IsValid){
            await SetKategoriDataSource();
            return View(request);
        }
        try{

            var product = request.ConvertToDbModel();

            //Insert to ProdukKategori table
            product.ProdukKategoris.Add(new Datas.Entities.ProdukKategori 
            {
                IdKategori = request.IdKategori,
                IdProduk = product.IdProduk
            });

            await _produkServices.Add(product);

            return Redirect(nameof(Index));
        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch(Exception) {
            throw;
        }


        await SetKategoriDataSource();
        return View(request);
    }

        public async Task<IActionResult> Delete(int id)
        {
            try{
                var delete = await _produkServices.Delete(id);
                if (delete){
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception){
            throw;
            }
            return View(new ProdukViewModel());
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