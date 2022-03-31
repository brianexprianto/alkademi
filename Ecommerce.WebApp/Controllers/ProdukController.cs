using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ecommerce.WebApp.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.WebApp.Controllers;

[Authorize]
public class ProdukController : Controller
{
    private readonly IProdukServices _produkServices;
    private readonly IKategoriServices _kategoriServices;
    private readonly IKategoriProdukServices _kategoriProdukServices;
    private readonly IWebHostEnvironment _iWebHost;
    private readonly ILogger<ProdukController> _logger;

    public ProdukController(ILogger<ProdukController> logger, 
    IProdukServices produkServices, 
    IKategoriServices kategoriServices, 
    IWebHostEnvironment iwebHost, 
    IKategoriProdukServices kategoriProdukServices)
    {
        _logger = logger;
        _produkServices = produkServices;
        _kategoriServices = kategoriServices;
        _iWebHost = iwebHost;
        _kategoriProdukServices = kategoriProdukServices;
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
                Kategories = dbResult[i].ProdukKategoris.Select(x => new KategoriViewModel {
                    IdKategori = x.IdKategori,
                    NamaKategori = x.IdKategoriNavigation.NamaKategori,
                    Icon = x.IdKategoriNavigation.Icon
                }).ToList()
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

    private async Task SetKategoriDataSource(int[] kategoris)
    {
        if(kategoris == null)
        {
            await SetKategoriDataSource();
            return;
        }

        var kategoriViewModels = await _kategoriServices.GetAll();

        ViewBag.KategoriDataSource = kategoriViewModels
        .Select(x => new SelectListItem
        {
            Value = x.IdKategori.ToString(),
            Text = x.NamaKategori,
            Selected = kategoris.FirstOrDefault(y => y == x.IdKategori) == 0 ? false : true
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

        if(request == null) {
            await SetKategoriDataSource();
            return View(request);
        }
        
        try{

            string fileName = string.Empty;
            
            if(request.GambarFile != null) 
            {
                fileName = $"{Guid.NewGuid()}-{request.GambarFile?.FileName}";

                string filePathName = _iWebHost.WebRootPath + "/images/" +fileName;
                
                using(var streamWriter = System.IO.File.Create(filePathName)){
                    //await streamWriter.WriteAsync(Common.StreamToBytes(request.GambarFile.OpenReadStream()));
                    //using extension to convert stream to bytes
                    await streamWriter.WriteAsync(request.GambarFile.OpenReadStream().ToBytes());
                }
            }

            var product = request.ConvertToDbModel();
            product.Gambar = $"images/{fileName}";

            //Insert to ProdukKategori table
            for (int i = 0; i < request.IdKategori.Length; i++)
            {
                product.ProdukKategoris.Add(new Datas.Entities.ProdukKategori 
                {
                    IdKategori = request.IdKategori[i],
                    IdProduk = product.IdProduk
                });
            }
            

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


    [HttpGet]
    public async Task<IActionResult> Edit(int? id) {

        if(id == null)
        {
            return BadRequest();
        }

        var produk = await _produkServices.Get(id.Value);

        if(produk == null) 
        {
            return NotFound();
        }

        var kategoriIds = await _kategoriProdukServices.GetKategoriIds(produk.IdProduk);

        await SetKategoriDataSource(kategoriIds);

        return View(new ProdukViewModel(){
            IdProduk = produk.IdProduk,
            NamaProduk = produk.NamaProduk,
            Deskripsi = produk.Deskripsi,
            Harga = produk.Harga,
            Gambar = produk.Gambar,
            IdKategori = kategoriIds
        });
    } 

    [HttpPost]
    public async Task<IActionResult> Edit(int? id, ProdukViewModel request) {
        if(!ModelState.IsValid){
            await SetKategoriDataSource();
            return View(request);
        }

        if(request == null) {
            await SetKategoriDataSource();
            return View(request);
        }

        try{
        
            string fileName = string.Empty;
            
            if(request.GambarFile != null) 
            {
                fileName = $"{Guid.NewGuid()}-{request.GambarFile?.FileName}";

                string filePathName = _iWebHost.WebRootPath + fileName;
                
                using(var streamWriter = System.IO.File.Create(filePathName)){
                    //await streamWriter.WriteAsync(Common.StreamToBytes(request.GambarFile.OpenReadStream()));
                    //using extension to convert stream to bytes
                    await streamWriter.WriteAsync(request.GambarFile.OpenReadStream().ToBytes());
                }
            }

            var product = request.ConvertToDbModel();
            product.Gambar = $"images/{fileName}";

            //Insert to ProdukKategori table
            for (int i = 0; i < request.IdKategori.Length; i++)
            { 
                product.ProdukKategoris.Add(new Datas.Entities.ProdukKategori 
                {
                    IdKategori = request.IdKategori[i],
                    IdProduk = product.IdProduk
                });   
            }

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

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProdukViewModel request)
        {
            if (id == null)
            {
                return NotFound();
            }

            try{
                await _produkServices.Delete(id.Value);
                return RedirectToAction(nameof(Index));  
            }
            catch(InvalidOperationException ex){
                ViewBag.ErrorMessage = ex.Message;
            }
            catch(Exception) {
                throw;
            }   
                return View(request);
        }

    // public async Task<IActionResult> Details(int? id){
    //     if(id == null)
    //     {
    //         return BadRequest();
    //     }

    //     var result = await _produkServices.Get(id.Value);

    //     if(result == null) {
    //         return NotFound();
    //     }

    //     return View(new ProdukViewModel(result));
    // }


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