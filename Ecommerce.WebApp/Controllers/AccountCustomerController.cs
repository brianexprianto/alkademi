using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Ecommerce.WebApp.Interfaces;

namespace Ecommerce.WebApp.Controllers;

public class AccountCustomerController : Controller
{
    private readonly ILogger<AccountCustomerController> _logger;
    private readonly IAccountServices _accountServices;

    public AccountCustomerController(ILogger<AccountCustomerController> logger, IAccountServices accountServices)
    {
        _logger = logger;
        _accountServices = accountServices;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login(){

        return View(new AccountLoginViewModel());
    }

    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AccountLoginViewModel request)
    {
        //Cocokan username dan password ke database
        var result = await _accountServices.LoginCustomer(request.Username, request.Password);

        if (result == null)
        {
            return View(new AccountLoginViewModel { });
        }

        try
        {
            #region set session login
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, result.IdCustomer.ToString()),
            new Claim(ClaimTypes.Email, result.Email ?? result.NamaCustomer),
            new Claim("FullName", result.NamaCustomer),
            new Claim(ClaimTypes.Role, AppConstant.CUSTOMER),
        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            #endregion

            return RedirectToActionPermanent("Index", "Home");
        }
        catch (System.Exception)
        {
            return View(request);
        }

    }

    public IActionResult Register() {

        return View(new RegisterViewModel());
    }

    public IActionResult Registered() {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel request) {

        if(!ModelState.IsValid) {
            return View(request);
        }

        try
        {
            await _accountServices.Register(request);

            return RedirectToAction("Registered", "AccountCustomer");
        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch (System.Exception)
        {
            throw;
        }

        return View(request);
    }
}