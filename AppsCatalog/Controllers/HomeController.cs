using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppsCatalog.Models;
using AppsCatalog.Data;
using Microsoft.EntityFrameworkCore;
using AppsCatalog.Models.enums;

namespace AppsCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applications.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string value, CategoryType category)
        {
            if (value != null && category != CategoryType.No)
            {
                return View(await _context.Applications.Where(x => x.Title == value).Where(x => x.Сategory == category).ToListAsync());
            }
            else
            {
                return value != null ? View(await _context.Applications.Where(x => x.Title == value).ToListAsync())
                     : View(await _context.Applications.Where(x => x.Сategory == category).ToListAsync());
            }
        }
    }
}
