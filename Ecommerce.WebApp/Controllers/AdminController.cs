using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ecommerce.WebApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.WebApp.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly IAdminServices _adminServices;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, IAdminServices adminServices)
    {
        _logger = logger;
        _adminServices = adminServices;
    }

    public IActionResult Index(){
        return View();
    }

    public async Task<IActionResult> IndexAdmin()
    {
        var dbResult = await _adminServices.GetAll();

        var viewModels = new List<AdminViewModel>();

        for (int i = 0; i < dbResult.Count; i++)
        {
            viewModels.Add(new AdminViewModel{
                IdAdmin = dbResult[i].IdAdmin,
                NamaAdmin = dbResult[i].NamaAdmin,
                NoHp = dbResult[i].NoHp,
                Username = dbResult[i].Username,
                Password = dbResult[i].Password,
            });
        }

        return View(viewModels);
    }

    public IActionResult Create() {
        return View(new AdminViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(AdminViewModel request) {
        if(!ModelState.IsValid){
            return View(request);
        }
        try{
            await _adminServices.Add(request.ConvertToDbModel());

            return Redirect(nameof(IndexAdmin));   
        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch(Exception) {
            throw;
        }

        return View(request);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id) 
    {

            if (id == null)
            {
                return NotFound();
            }
            var result = await _adminServices.Get(id.Value);

            if (result == null)
            {
                return NotFound();
            }
            return View(new AdminViewModel(result));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int? id, AdminViewModel request) {
        if(!ModelState.IsValid){
            return View(request);
        }

        try{
            await _adminServices.Update(request.ConvertToDbModel());

            return RedirectToAction(nameof(IndexAdmin));   

        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch(Exception) {
            throw;
        }

        return View(request);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id) 
    {

            if (id == null)
            {
                return NotFound();
            }
            var result = await _adminServices.Get(id.Value);

            if (result == null)
            {
                return NotFound();
            }
            return View(new AdminViewModel(result));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id, AdminViewModel request) {
        if(id == null) {
            return BadRequest();
        }
        try{
            await _adminServices.Delete(id.Value);

            return RedirectToAction(nameof(IndexAdmin));   

        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch(Exception) {
            throw;
        }

        return View(request);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}