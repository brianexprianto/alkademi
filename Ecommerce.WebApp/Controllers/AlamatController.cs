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

namespace Ecommerce.WebApp.Controllers;

[Authorize(Roles = AppConstant.CUSTOMER)]
public class AlamatController : Controller
{
     private readonly ILogger<AlamatController> _logger;
     private readonly IAlamatServices _alamatServices;
     public AlamatController(ILogger<AlamatController> logger, IAlamatServices alamatServices)
     {
          _logger = logger;
          _alamatServices = alamatServices;
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

     public async Task<IActionResult> Index()
     {
          var result = new List<AlamatViewModel>();
          var data = await _alamatServices.GetAll(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt());
          foreach (var item in data)
          {
               result.Add(new AlamatViewModel
               {
                    IdAlamat = item.IdAlamat,
                    Prov = item.Prov,
                    KabKota = item.KabKota,
                    Kec = item.Kec,
                    Kel = item.Kel,
                    KodePos = item.KodePos,
                    DetailAlamat = item.DetailAlamat
               });
          }
          return View(result);
     }

     // GET
     public ActionResult Create()
     {
          return View(new AlamatViewModel()
          {
               IdCustomer = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt()
          });
     }

     // POST
     [HttpPost]
     public async Task<IActionResult> Create(AlamatViewModel request)
     {
          if (!ModelState.IsValid)
          {
               return View(request);
          }
          if (request == null)
          {
               return View(request);
          }

          try
          {
               await _alamatServices.Add(request.ConvertToDbModel());
               return RedirectToAction(nameof(Index));

          }
          catch (InvalidOperationException ex)
          {
               ViewBag.ErrorMessage = ex.Message;
          }
          catch (Exception)
          {
               throw;
          }
          return View(request);
     }

     // GET
     public async Task<IActionResult> Edit(int? id)
     {
          if (id == null)
          {
               return new NotFoundResult();
          }

          var data = await _alamatServices.Get(id.Value);
          if (data == null)
          {
               return NotFound();
          }

          return View(new AlamatViewModel()
          {
               Prov = data.Prov,
               KabKota = data.KabKota,
               Kec = data.Kec,
               Kel = data.Kel,
               KodePos = data.KodePos,
               DetailAlamat = data.DetailAlamat
          });
     }

     // POST
     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> Edit(int? id, AlamatViewModel request)
     {
          if (id == null)
          {
               return BadRequest();
          }
          if (!ModelState.IsValid)
          {
               return View(request);
          }
          try
          {
               request.IdAlamat = id.Value;
               var updated = await _alamatServices.Update(request.ConvertToDbModel());
               return RedirectToAction(nameof(Index));
          }
          catch (InvalidOperationException ex)
          {
               ViewBag.ErrorMessage = ex.Message;
          }
          catch (Exception)
          {
               throw;
          }
          return View(request);

     }

     public async Task<IActionResult> Delete(int id)
     {
          try
          {
               var deleted = await _alamatServices.Delete(id);
               if (deleted)
               {
                    return RedirectToAction(nameof(Index));
               }
          }
          catch (Exception)
          {
               throw;
          }
          return View(new KategoriViewModel());
     }

}