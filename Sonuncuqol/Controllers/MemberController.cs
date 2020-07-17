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
    public class MemberController : Controller
    {
        private readonly SqDbContext _context;
        private readonly IMapper _mapper;

        public MemberController(SqDbContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var member = _context.Writers.Where(s => s.Status).ToList();
                
            var model = _mapper.Map<IEnumerable<Writer>,IEnumerable<WriterViewModel>>(member);

            return View(model);
        }
    }
}