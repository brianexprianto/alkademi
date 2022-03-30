using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ecommerce.WebApp.Helpers;

namespace Ecommerce.WebApp.Controllers;

public class KategorisController : Controller
{
    private readonly IKategoriServices _kategoriServices;
    private readonly IWebHostEnvironment _iWebHost;
    private readonly ILogger<KategorisController> _logger;

    public KategorisController(ILogger<KategorisController> logger, IKategoriServices kategoriServices, IWebHostEnvironment iwebHost)
    {
        _logger = logger;
        _kategoriServices = kategoriServices;
        _iWebHost = iwebHost;
    }

    public async Task<IActionResult> Index()
    {
        var dbResult = await _kategoriServices.GetAll();

        var viewModels = new List<KategoriViewModel>();

        for (int i = 0; i < dbResult.Count; i++)
        {
            viewModels.Add(new KategoriViewModel{
                IdKategori = dbResult[i].IdKategori,
                NamaKategori = dbResult[i].NamaKategori,
                Deskripsi = dbResult[i].Deskripsi,
                Icon = dbResult[i].Icon,
            });
        }

        return View(viewModels);
    }

    public IActionResult Create() {
        return View(new KategoriViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(KategoriViewModel request) {
        if(!ModelState.IsValid){
            return View(request);
        }
        try{
            string fileName = string.Empty;
            
            if(request.IconFile != null) 
            {
                fileName = $"{request.IconFile?.FileName}";

                string filePathName = _iWebHost.WebRootPath + "/icons/" +fileName;
                
                using(var streamWriter = System.IO.File.Create(filePathName)){
                    //await streamWriter.WriteAsync(Common.StreamToBytes(request.GambarFile.OpenReadStream()));
                    //using extension to convert stream to bytes
                    await streamWriter.WriteAsync(request.IconFile.OpenReadStream().ToBytes());
                }
            }

            request.Icon = $"icons/{fileName}";

            await _kategoriServices.Add(request.ConvertToDbModel());

            return Redirect(nameof(Index));   
        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch(Exception) {
            throw;
        }

        return View(request);
    }
    public async Task<IActionResult> Details(int? id){
        if(id == null)
        {
            return BadRequest();
        }

        var result = await _kategoriServices.Get(id.Value);

        if(result == null) {
            return NotFound();
        }

        return View(new KategoriViewModel(result));
    }
    // public async Task<IActionResult> Details(int? id)
    //     {
    //         if (id == null)
    //         {
    //             return NotFound();
    //         }

    //         var kategori = await _context.KategoriProduks
    //             .FirstOrDefaultAsync(m => m.IdKategori == id);
    //         if (kategori == null)
    //         {
    //             return NotFound();
    //         }

    //         return View(kategori);
    //     }

    public async Task<IActionResult> Edit(int? id)
    {
    if (id == null)
    {
        return NotFound();
    }
    var result = await _kategoriServices.Get(id.Value);
    if (result == null){
        return NotFound();
    }
    return View(new KategoriViewModel(result));
    }


    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, KategoriViewModel request)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return View(request);
            }

            try{
                await _kategoriServices.Update(request.ConvertToDbModel());
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


    //action delete
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
    {
        return NotFound();
    }
    var result = await _kategoriServices.Get(id.Value);
    if (result == null){
        return NotFound();
    }
    return View(new KategoriViewModel(result));
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, KategoriViewModel request)
        {
            if (id == null)
            {
                return NotFound();
            }

            try{
                await _kategoriServices.Delete(id.Value);
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

        
        // public async Task<IActionResult> Delete(int id)
        // {
        //     try{
        //         var delete = await _kategoriServices.Delete(id);
        //         if (delete){
        //             return RedirectToAction(nameof(Index));
        //         }
        //     }
        //     catch (Exception){
        //     throw;
        //     }
        //     return View(new KategoriViewModel());
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