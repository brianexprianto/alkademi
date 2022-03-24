 
using Alkademi.Bootcamp.HelloWebApp.Models;
using Alkademi.Bootcamp.HelloWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alkademi.Bootcamp.HelloWebApp.Controllers
{
    public class UserController : Controller
    {
        List<UserViewModel> _listUser = new List<UserViewModel>();
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
            _listUser = new List<UserViewModel>(){
            new UserViewModel(1, "brianexp","brian123"),
            new UserViewModel(2, "brianexp","brian123"),
            new UserViewModel(3, "brianexp","brian123"),
            new UserViewModel(4, "brianexp","brian123"),
           
        };
        }

        
        // GET: TweetController
        public ActionResult Index()
        {
            return View(_userService.GetUsers());
        }

        // GET: TweetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TweetController/Create
        public ActionResult Create()
        {
            return View(new UserViewModel(1, "usename ", "password"));
        }

        // POST: TweetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel collection)
        {
            if(!ModelState.IsValid)
            {
                return View(collection);
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: TweetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TweetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TweetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TweetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
