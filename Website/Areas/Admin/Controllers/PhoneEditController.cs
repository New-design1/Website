using Microsoft.AspNetCore.Mvc;
using Website.Domain;
using Website.Domain.Entities;

namespace Website.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PhoneEditController : Controller
	{
		AppDbContext context;
		IWebHostEnvironment hostingEnvironment;

		public PhoneEditController(AppDbContext context, IWebHostEnvironment hostingEnvironment) 
		{ 
			this.context = context;
			this.hostingEnvironment = hostingEnvironment;
		}
		public IActionResult AddPhone()
		{
			//var ph = new Phone()
			//{
			//	Id = Guid.NewGuid(),
			//	Color = "blue",
			//	ScreenDiagonal = "4.5",
			//	CoresCount = "5"
			//};
			//context.Phones.Add(ph);
			//context.SaveChanges();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddPhone(Phone phone)
		{
			//if(ModelState.IsValid) 
			//{
				if (Request.Form.Files != null)
				{
					int imgNum = 1;
					foreach (var img in Request.Form.Files)
					{
						using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/phones/", img.FileName), FileMode.Create))
						{
							img.CopyTo(stream);
						}
						string path = Path.Combine("/images/phones/", img.FileName);
						Type type = typeof(Phone);
						var imgProp = type.GetProperty("ImagePath" + imgNum++.ToString());
						imgProp.SetValue(phone, path);
					}
				}
			//}
			context.Phones.Add(phone);
			await context.SaveChangesAsync();
			return View();
		}
	}
}
