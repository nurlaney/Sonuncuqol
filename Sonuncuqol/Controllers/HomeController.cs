using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sonuncuqol.Data;
using Sonuncuqol.Models;
using Sonuncuqol.ViewModels;

namespace Sonuncuqol.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
                              SqDbContext context,
                              IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var posts = _context.Posts.Include("Writer").Include("Label").Where(s => s.Status).OrderByDescending(s => s.AddedDate).ToList();
            var sliderItems = _context.SliderItems.Where(s => s.Status).OrderByDescending(s => s.AddedDate).ToList();

            var model = new HomeViewModel
            {
                Posts = _mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(posts),
                SliderItems = _mapper.Map<IEnumerable<SliderItem>, IEnumerable<SliderItemViewModel>>(sliderItems),
            };

            return View(model);
        }

        public IActionResult Privacy()
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
