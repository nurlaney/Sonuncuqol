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

namespace Sonuncuqol.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(Auth))]
    public class LabelController : Controller
    {
        private Sonuncuqol.Models.Admin _admin => RouteData.Values["Admin"] as Sonuncuqol.Models.Admin;
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;

        public LabelController(SqDbContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var labels = _context.Labels.OrderByDescending(l => l.AddedDate).ToList();

            var model = _mapper.Map<IEnumerable<Label>,IEnumerable<LabelAViewModel>>(labels);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LabelAViewModel model)
        {
            if (ModelState.IsValid)
            {
                var label = _mapper.Map<LabelAViewModel, Label>(model);

                label.AddedBy = _admin.Fullname;
                label.AddedDate = DateTime.Now;

                _context.Add(label);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var label = _context.Labels.FirstOrDefault(l => l.Id == id);

            if (label == null) return NotFound();

            var model = _mapper.Map<Label, LabelAViewModel>(label);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LabelAViewModel model)
        {
            if (ModelState.IsValid)
            {
                var label = _mapper.Map<LabelAViewModel, Label>(model);

                var labelToUpdate = _context.Labels.FirstOrDefault(l => l.Id == model.Id);

                if (labelToUpdate == null) return NotFound();

                label.ModifiedBy = _admin.Fullname;

                labelToUpdate.Status = label.Status;
                labelToUpdate.Text = label.Text;
                labelToUpdate.ModifiedDate = DateTime.Now;

                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return Ok(model);
        }

        public IActionResult Delete(int id)
        {
            Label label = _context.Labels.FirstOrDefault(l => l.Id == id);

            if (label == null) return NotFound();

            _context.Remove(label);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}