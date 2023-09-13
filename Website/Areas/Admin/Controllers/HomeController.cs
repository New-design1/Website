using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Website.Domain;

namespace Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
   

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task Image()
        //{
        //    string content = @"<form method='post' enctype='multipart/form-data'>" +
        //        "<input type='file' name='file' /><br />" +
        //        "<input type='submit' value='Send' />" +
        //        "</form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(content);
        //}

        //[HttpPost]
        //public void Image(IFormFile file)
        //{
        //    using (var stream = new FileStream(@"C:\Users\User1\Desktop\image.jpg", FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }
        //}
    }
}