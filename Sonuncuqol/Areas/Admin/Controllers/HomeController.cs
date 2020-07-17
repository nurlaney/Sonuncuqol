using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sonuncuqol.Areas.Admin.Filters;

namespace Sonuncuqol.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(Auth))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}