using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sonuncuqol.Data;
using Sonuncuqol.Models;
using Sonuncuqol.ViewModels;

namespace Sonuncuqol.Controllers
{
    public class PostController : Controller
    {
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;

        public PostController(SqDbContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index(int id)
        {
            var singlePost = _context.Posts
                                           .Include("Writer")
                                           .Include("Label")
                                           .FirstOrDefault(s => s.Id == id);

            ViewBag.posts = _context.Posts.Include("Label").Include("Writer").Where(s => s.Status && s.Id != id).OrderByDescending(s=>s.AddedDate).ToList();

            var model = _mapper.Map<Post, PostViewModel>(singlePost);


            return View(model);
        }
    }
}