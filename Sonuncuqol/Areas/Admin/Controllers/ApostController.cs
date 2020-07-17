using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sonuncuqol.Areas.Admin.Filters;
using Sonuncuqol.Areas.Admin.Libs;
using Sonuncuqol.Areas.Admin.Models;
using Sonuncuqol.Data;
using Sonuncuqol.Models;

namespace Sonuncuqol.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(Auth))]
    public class ApostController : Controller
    {
        private Sonuncuqol.Models.Admin _admin => RouteData.Values["Admin"] as Sonuncuqol.Models.Admin;
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public ApostController(SqDbContext context,
                                 IMapper mapper,
                                 IFileManager fileManager)
        {
            _context = context;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var posts = _context.Posts.Include("Writer").Include("Label").OrderByDescending(p => p.AddedDate).ToList();

            var model = _mapper.Map<IEnumerable<Post>,IEnumerable< ApostViewModel >> (posts);

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.labels = _context.Labels.Where(l => l.Status).OrderByDescending(c => c.AddedDate).ToList();
            ViewBag.writers = _context.Writers.Where(w => w.Status).OrderByDescending(c => c.AddedDate).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApostViewModel model)
        {
            if (model == null) return NotFound();

            if (ModelState.IsValid)
            {
                var post = _mapper.Map<ApostViewModel, Post>(model);

                post.AddedBy = _admin.Fullname;
                post.AddedDate = DateTime.Now;

                if(model.LabelId == 0)
                {
                    post.LabelId = null;
                }

                if (model.File != null)
                {
                    post.Image = _fileManager.Upload(model.File);
                }
                else
                {
                    post.Image = null;
                }
                post.WriterId = model.WriterId;

                _context.Add(post);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.labels = _context.Labels.Where(l => l.Status).OrderByDescending(c => c.AddedDate).ToList();
            ViewBag.writers = _context.Writers.Where(w => w.Status).OrderByDescending(c => c.AddedDate).ToList();

            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null) return NotFound();

            var model = _mapper.Map<Post, ApostViewModel>(post);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApostViewModel model)
        {
            var post = _mapper.Map<ApostViewModel, Post>(model);

            if (ModelState.IsValid)
            {

                var postToUpdate = _context.Posts.FirstOrDefault(p => p.Id == model.Id);
               
                if (model.LabelId == 0)
                {
                    post.LabelId = null;
                }


                if (postToUpdate == null) return NotFound();

                if (model.File == null) 
                {
                    post.Image = postToUpdate.Image;
                }
                else
                {

                    _fileManager.Delete(postToUpdate.Image);

                    post.Image = _fileManager.Upload(model.File);

                }


                post.ModifiedBy = _admin.Fullname;
                postToUpdate.ModifiedDate = DateTime.Now;
                postToUpdate.Text = post.Text;
                postToUpdate.Description = post.Description;
                postToUpdate.Status = post.Status;
                postToUpdate.IsFeatured = post.IsFeatured;
                postToUpdate.Title = post.Title;
                postToUpdate.LabelId = post.LabelId;
                postToUpdate.WriterId = post.WriterId;
                postToUpdate.Image = post.Image;

                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            _context.Remove(post);

            if (post.Image != null)
            {
                _fileManager.Delete(post.Image);

            }
            _context.SaveChanges();


            return RedirectToAction("index");
        }
    }
}