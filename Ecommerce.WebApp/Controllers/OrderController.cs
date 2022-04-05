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
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.Controllers;

[Authorize(Roles = AppConstant.CUSTOMER)]
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IKeranjangServices _keranjangServices;
    private readonly IOrderServices _orderServices;

    public OrderController(ILogger<OrderController> logger, IKeranjangServices keranjangServices,
    IOrderServices orderServices)
    {
        _logger = logger;
        _keranjangServices = keranjangServices;
        _orderServices = orderServices;
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

    public override void OnActionExecuting(ActionExecutingContext context){

        base.OnActionExecuting(context);
    }


    public async Task<IActionResult> Index()
    {

        var result = await _orderServices.Get(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt());

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Checkout(CheckoutViewModel? request)
    {
        if(request == null)
        {
            return BadRequest();
        }

        if(request.Alamat == 0)
        {
            return BadRequest();
        }

        int idCustomer = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt();
        var result = await _keranjangServices.Get(idCustomer);

        if(result == null || !result.Any())
        {
            return BadRequest();
        }

        foreach (var item in result)
        {
            int keranjangId = request.Id.FirstOrDefault(x=> item.IdKeranjang == x);

            if(keranjangId < 1)
            {
                continue;
            }
            int jumlahBarangBaru = request.Qty[Array.IndexOf(request.Id, keranjangId)];

            item.JlhBarang = jumlahBarangBaru;
            item.Subtotal = item.HargaBarang * jumlahBarangBaru;
        }

        var newOrder = new Orderr();

        newOrder.IdCustomer = idCustomer;
        newOrder.JlhBayar = result.Sum(x=>x.Subtotal);
        newOrder.Notes = request.Notes;
        newOrder.IdStatus = 1;
        newOrder.IdAlamat = request.Alamat;
        newOrder.TglTransaksi = DateOnly.FromDateTime(DateTime.Now);
        newOrder.DetailOrders = new List<DetailOrder>();

        foreach(var item in result)
        {
            newOrder.DetailOrders.Add(new DetailOrder
            {
                Id = newOrder.IdOrder,
                Harga = item.HargaBarang,
                JlhBarang = item.JlhBarang,
                Subtotal = item.Subtotal,
                IdProduk = item.IdProduk
            });
        }

        await _orderServices.Checkout(newOrder);

        await _keranjangServices.Clear(idCustomer);

        return RedirectToAction(nameof(CheckoutBerhasil));
    }

    public IActionResult CheckoutBerhasil(){
        return View();
    }
}