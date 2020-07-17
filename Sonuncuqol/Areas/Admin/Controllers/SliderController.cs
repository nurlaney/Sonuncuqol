using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sonuncuqol.Areas.Admin.Filters;
using Sonuncuqol.Areas.Admin.Libs;
using Sonuncuqol.Areas.Admin.Models;
using Sonuncuqol.Data;
using Sonuncuqol.Models;

namespace Sonuncuqol.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(Auth))]
    public class SliderController : Controller
    {
        private Sonuncuqol.Models.Admin _admin => RouteData.Values["Admin"] as Sonuncuqol.Models.Admin;
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public SliderController(SqDbContext context,
                                 IMapper mapper,
                                 IFileManager fileManager)
        {
            _context = context;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var sliders = _context.SliderItems.OrderByDescending(w => w.AddedDate).ToList();

            var model = _mapper.Map<IEnumerable<SliderItem>, IEnumerable<SliderViewModel>>(sliders);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SliderViewModel model)
        {
            if (model == null) return NotFound();

            if (ModelState.IsValid)
            {
                var slider = _mapper.Map<SliderViewModel, SliderItem>(model);

                slider.AddedBy = _admin.Fullname;
                slider.AddedDate = DateTime.Now;

                if (model.File != null)
                {
                    slider.Image = _fileManager.Upload(model.File);
                }
                else
                {
                    slider.Image = null;
                }

                _context.Add(slider);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var slider = _context.SliderItems.FirstOrDefault(w => w.Id == id);

            var model = _mapper.Map<SliderItem, SliderViewModel>(slider);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SliderViewModel model)
        {
            var slider = _mapper.Map<SliderViewModel, SliderItem>(model);

            if (model == null) return NotFound();

            if (ModelState.IsValid)
            {
                var updateSlider = _context.SliderItems.FirstOrDefault(w => w.Id == model.Id);

                updateSlider.ModifiedBy = _admin.Fullname;
                updateSlider.ModifiedDate = DateTime.Now;

                if (model.File == null)
                {
                    slider.Image = updateSlider.Image;
                }
                else
                {

                    _fileManager.Delete(updateSlider.Image);

                    slider.Image = _fileManager.Upload(model.File);

                }


                updateSlider.Status = slider.Status;
                updateSlider.Title = slider.Title;
                updateSlider.Description = slider.Description;
                updateSlider.Image = slider.Image;

                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var slider = _context.SliderItems.FirstOrDefault(w => w.Id == id);

            _context.Remove(slider);

            if (slider.Image != null)
            {
                _fileManager.Delete(slider.Image);

            }
            _context.SaveChanges();


            return RedirectToAction("index");
        }
    }
}