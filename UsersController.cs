using auth_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace auth_task.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            user.CreatedAT = DateTime.Now;
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
   
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var CheckUser = context.Users.Where(e=> e.UserName == user.UserName && e.Password == user.Password).FirstOrDefault();
            if (CheckUser != null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "Invalid UserName or Password";
            return View(user);
        }
        public IActionResult Index()
        {
            
            var user = context.Users.Where(e=> e.IsActive == false).AsNoTracking().ToList();
            
            return View(user);
        }
        public IActionResult Active(Guid id)
        {
            var active = context.Users.Where(e=> e.UserId == id).FirstOrDefault();
            if (active != null)
            {
                active.IsActive = true;
                context.SaveChanges(); 

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
