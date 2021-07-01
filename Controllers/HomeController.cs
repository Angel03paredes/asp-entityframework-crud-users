using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using entityframework.Models;
using System.Dynamic;

namespace entityframework.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _userContext;

        public HomeController(UserContext userContext)
        {
            this._userContext = userContext;
        }



        public IActionResult Index()
        {


            var users = _userContext.Users.ToArray();
           // var user = new User();
          // ViewData["user"] = user;
            ViewData["users"] = users;

            return View();
        }

          public IActionResult Update(string id)
        {
            var users = _userContext.Users.ToArray();
            var user = _userContext.Users.Find(Guid.Parse(id));
            ViewData["user"] = user;
            ViewData["users"] = users;
            
            return View("./Index",user);
        }


        [HttpPost]
          public IActionResult Update(User user)
        {
            _userContext.Users.Update(user);
            _userContext.SaveChanges();

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult Index(User user)
        {   
            user.id = Guid.NewGuid();
            _userContext.Add(user);
            _userContext.SaveChanges();
            return Redirect("/");
        }   

       
        public IActionResult Delete(string id){
            var idUser = _userContext.Users.Single(a=> a.id == Guid.Parse(id));
            _userContext.Remove(idUser);
            _userContext.SaveChanges();
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
