using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.Domain;
using Website.Domain.Entities;

namespace Website.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext dbContext;

        public ProductController(AppDbContext context)
        {
            dbContext = context;
        }

        // GET: ProductController
        public ActionResult ProductPage(Guid id)
        {
			// var phone  = dbContext.Phones.FirstOrDefault(x => x.Id == id);
			var phone = dbContext.Phones.Include(p => p.PhoneExamples).ThenInclude(p => p.Example).ThenInclude(p => p.Characteristic).Include(p => p.PhoneImages).ThenInclude(p => p.Image).FirstOrDefault(p => p.Id == id);
			return View(phone);
        }
    }
}
