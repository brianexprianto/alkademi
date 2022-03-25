 
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
        private readonly IFileUserService _fileUserService;
        public UserController(IUserService userService, IFileUserService fileUserService)
        {
            _userService = userService;
            _fileUserService = fileUserService;
            _listUser = new List<UserViewModel>(){
            new UserViewModel(1, "brianexp","brian123"),
            new UserViewModel(1, "brianexp","brian123"),
            new UserViewModel(1, "brianexp","brian123"),
            new UserViewModel(1, "brianexp","brian123"),
           
        };

        }

        
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var data = await _fileUserService.Read();
            
            return View(data);
        }

        // GET: TweetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TweetController/Create
        public ActionResult Create()
        {
            return View(new UserViewModel(1, "username ", "password"));
        }

        // POST: TweetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel collection)
        {
            if(!ModelState.IsValid)
            {
                return View(collection);
            }

            try
            {
                await _fileUserService.Write(collection);
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
