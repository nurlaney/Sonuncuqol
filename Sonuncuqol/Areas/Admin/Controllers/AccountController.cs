using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sonuncuqol.Areas.Admin.Models;
using Sonuncuqol.Data;

namespace Sonuncuqol.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SqDbContext _context;

        public AccountController(SqDbContext context)
        {
            _context = context;
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Sonuncuqol.Models.Admin admin = _context.Admins.FirstOrDefault(a => a.Email == model.Email);

                if (admin != null && CryptoHelper.Crypto.VerifyHashedPassword(admin.Password, model.Password))
                {
                    admin.Token = Guid.NewGuid().ToString();

                    Sonuncuqol.Models.Admin LoginnedAdmin = _context.Admins.Find(admin.Id);

                    admin.Token = LoginnedAdmin.Token;

                    _context.SaveChanges();

                    Response.Cookies.Append("admin-token", admin.Token, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        HttpOnly = true,
                        Expires = model.RememberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddDays(1)
                    });

                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError("Password", "Şifrə vəya istifadəçi adı səhvdir !");
            }

            return View(model);
        }
    }
}