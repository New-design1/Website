using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Website.Domain;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var phones = dbContext.Phones.Include(p => p.PhoneExamples).ThenInclude(p => p.Example).Include(p => p.PhoneImages).ThenInclude(p => p.Image).ToList();
            //var df = phones[0].PhoneImages[0].Image.Path;
            return View(phones);
           
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