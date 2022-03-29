using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.Interfaces;

namespace Ecommerce.WebApp.Controllers;

public class KategorisController : Controller
{
    private readonly IKategoriServices _kategoriServices;
    private readonly ILogger<KategorisController> _logger;

    public KategorisController(ILogger<KategorisController> logger, IKategoriServices kategoriServices)
    {
        _logger = logger;
        _kategoriServices = kategoriServices;
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
    public async Task<IActionResult> Create(KategoriViewModel request) {
        if(!ModelState.IsValid){
            return View(request);
        }
        try{
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

    // public async Task<IActionResult> Edit(int? id)
    // {
    // if (id == null)
    // {
    //     return NotFound();
    // }
    // var kategori = await _kategoriServices.KategoriProduks.FindAsync(id);
    // if (kategori == null){
    //     return NotFound();
    // }
    // return View(kategori);
    // }

    
    // public async Task<IActionResult> Edit(int? id)
    //     {
    //         if (id == null)
    //         {
    //             return NotFound();
    //         }

    //         var kategori = await _kategoriServices.Kategoris.FindAsync(id);
    //         if (kategori == null)
    //         {
    //             return NotFound();
    //         }
    //         return View(kategori);
    //     }
    
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("IdKategori,NamaKategori,Deskripsi,Icon")] KategoriViewModel kategori)
        // {
        //     if (id != kategori.IdKategori)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _kategoriServices.Update(kategori);
        //             await _kategoriServices.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!KategoriExists(kategori.IdKategori))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(kategori);
        // }

        
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var delete = await _kategoriServices.Delete(id);
                if (delete){
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception){
            throw;
            }
            return View(new KategoriViewModel());
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