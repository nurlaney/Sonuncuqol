using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sonuncuqol.Areas.Admin.Filters;
using Sonuncuqol.Areas.Admin.Models;
using Sonuncuqol.Data;
using Sonuncuqol.Models;
using Sonuncuqol.ViewModels;

namespace Sonuncuqol.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(Auth))]
    public class AboutUsController : Controller
    {
        private Sonuncuqol.Models.Admin _admin => RouteData.Values["Admin"] as Sonuncuqol.Models.Admin;
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;

        public AboutUsController(SqDbContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var company = _context.Companies.ToList();
            var model = _mapper.Map<IEnumerable<Company>, IEnumerable<AboutUsViewModel>>(company);

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var about = _context.Companies.FirstOrDefault(c => c.Id == id);

            if (about == null) return NotFound();

            var model = _mapper.Map<Company, AboutUsViewModel>(about);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AboutUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var about = _mapper.Map<AboutUsViewModel, Company>(model);

                var aboutToUpdate = _context.Companies.FirstOrDefault(c => c.Id == model.Id);


                if (aboutToUpdate == null) return NotFound();

                about.ModifiedBy = _admin.Fullname;
                aboutToUpdate.ModifiedDate = DateTime.Now;
                aboutToUpdate.Text = about.Text;
                aboutToUpdate.Description = about.Description;
                aboutToUpdate.Status = about.Status;

                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}