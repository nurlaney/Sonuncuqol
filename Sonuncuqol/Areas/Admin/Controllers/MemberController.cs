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
    public class MemberController : Controller
    {
        private Sonuncuqol.Models.Admin _admin => RouteData.Values["Admin"] as Sonuncuqol.Models.Admin;
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public MemberController(SqDbContext context,
                                 IMapper mapper,
                                 IFileManager fileManager)
        {
            _context = context;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var members = _context.Writers.OrderByDescending(w => w.AddedDate).ToList();

            var model = _mapper.Map<IEnumerable<Writer>, IEnumerable<MemberViewModel>>(members);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberViewModel model)
        {
            if (model == null) return NotFound();

            if (ModelState.IsValid)
            {
                var member = _mapper.Map<MemberViewModel, Writer>(model);

                member.AddedBy = _admin.Fullname;
                member.AddedDate = DateTime.Now;

                if (model.File != null)
                {
                    member.Image = _fileManager.Upload(model.File);
                }
                else
                {
                    member.Image = null;
                }

                _context.Add(member);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var member = _context.Writers.FirstOrDefault(w => w.Id == id);

            var model = _mapper.Map<Writer, MemberViewModel>(member);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MemberViewModel model)
        {
            var member = _mapper.Map<MemberViewModel, Writer>(model);

            if (model == null) return NotFound();

            if (ModelState.IsValid)
            {
                var updateMember = _context.Writers.FirstOrDefault(w => w.Id == model.Id);

                updateMember.ModifiedBy = _admin.Fullname;
                updateMember.ModifiedDate = DateTime.Now;

                if (model.File == null)
                {
                    member.Image = updateMember.Image;
                }
                else
                {

                    _fileManager.Delete(updateMember.Image);

                    member.Image = _fileManager.Upload(model.File);

                }


                updateMember.Status = member.Status;
                updateMember.FullName = member.FullName;
                updateMember.Description = member.Description;
                updateMember.Image = member.Image;

                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var member = _context.Writers.FirstOrDefault(w => w.Id == id);

            _context.Remove(member);

            if (member.Image != null)
            {
                _fileManager.Delete(member.Image);

            }
            _context.SaveChanges();


            return RedirectToAction("index");
        }
    }
}