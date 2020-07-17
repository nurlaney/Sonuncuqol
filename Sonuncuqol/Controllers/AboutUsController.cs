using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sonuncuqol.Data;
using Sonuncuqol.Models;
using Sonuncuqol.ViewModels;

namespace Sonuncuqol.Controllers
{
    public class AboutUsController : Controller
    {
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
            var data = _context.Companies.Where(s => s.Status).ToList();

            if (data == null) return NotFound();

            var model = _mapper.Map<Company, CompanyViewModel>(data.First());

            if (model == null) return NotFound();

            return View(model);
        }
    }
}