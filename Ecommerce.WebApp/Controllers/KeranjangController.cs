using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.WebApp.Interfaces;
using System.Security.Claims;
using Ecommerce.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.WebApp.Controllers;

[Authorize(Roles = AppConstant.CUSTOMER)]
public class KeranjangController : Controller
{
    private readonly ILogger<KeranjangController> _logger;
    private readonly IKeranjangServices _keranjangServices;
    private readonly IAccountServices _accountServices;

    public KeranjangController(ILogger<KeranjangController> logger, IKeranjangServices keranjangServices,
    IAccountServices accountServices)
    {
        _logger = logger;
        _keranjangServices = keranjangServices;
        _accountServices = accountServices;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if(HttpContext.User == null || HttpContext.User.Identity == null){
            ViewBag.IsLogged = false;
        } else {
            ViewBag.IsLogged = HttpContext.User.Identity.IsAuthenticated;
        }

        base.OnActionExecuted(context);
    }

    public async Task<IActionResult> Index(){

        int idCustomer = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt();
        var result = await _keranjangServices.Get(idCustomer);
        var alamat = await _accountServices.GetAlamat(idCustomer);
        ViewBag.AlamatList = alamat.Select(x=> new SelectListItem(x.Item2.ToString(), x.Item1.ToString())).ToList();
        
        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int? idProduk)
    {
        if(idProduk == null)
        {
            return BadRequest();
        }

        await _keranjangServices.Add(new Datas.Entities.Keranjang
        {
            IdProduk = idProduk.Value,
            JlhBarang = 1,
            IdCustomer = HttpContext.User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value.ToInt()
        });

        return RedirectToAction(nameof(Index));
    }
}