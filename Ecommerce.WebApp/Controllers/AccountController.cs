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

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountServices _accountServices;

    public AccountController(ILogger<AccountController> logger, IAccountServices accountServices)
    {
        _logger = logger;
        _accountServices = accountServices;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {

        return View(new AccountLoginViewModel());
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Login(AccountLoginViewModel request)
    {
        //Cocokan username dan password ke database
        var result = await _accountServices.Login(request.Username, request.Password);

        if (result == null)
        {
            return View(new AccountLoginViewModel { });
        }

        try
        {
            #region set session login
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, result.NoHp ?? result.NamaAdmin),
            new Claim("FullName", result.NamaAdmin),
            new Claim(ClaimTypes.Role, "Administrator"),
        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            #endregion

            return RedirectToActionPermanent("Index", "Produk");
        }
        catch (System.Exception)
        {
            return View(request);
        }

    }


    // public IActionResult Create() {
    //     return View(new AccountLoginViewModel());
    // }

    // [HttpPost]
    // public async Task<IActionResult> Create(AccountLoginViewModel request) {
    //     if(!ModelState.IsValid){
    //         return View(request);
    //     }
    //     try{
    //         await _accountServices.Add(request.ConvertToDbModel());

    //         return Redirect(nameof(Index));   
    //     }catch(InvalidOperationException ex){
    //         ViewBag.ErrorMessage = ex.Message;
    //     }
    //     catch(Exception) {
    //         throw;
    //     }

    //     return View(request);
    // }




}