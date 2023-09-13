using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using Website.Domain;
using Website.Domain.Entities;

namespace Website.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PhoneEditController : Controller
	{
		AppDbContext dbContext;
		IWebHostEnvironment hostingEnvironment;
		List<Characteristic> characteristics;

		public PhoneEditController(AppDbContext context, IWebHostEnvironment hostingEnvironment) 
		{ 
			dbContext = context;
			this.hostingEnvironment = hostingEnvironment;
			characteristics = dbContext.Characteristics.ToList();
		}
		
		public IActionResult AddPhone()
		{
			
			return View(characteristics);
		}

		[HttpPost]
		public async Task<IActionResult> AddPhone(Phone phone, params string[] values)
		{
			//if(ModelState.IsValid) 
			//{
			dbContext.Phones.Add(phone);

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
					Image image = new Image() { Path = path };
					dbContext.Images.Add(image);
					dbContext.PhoneImages.Add(new PhoneImage() { Phone = phone, Image = image });
					//Type type = typeof(Phone);
					//var imgProp = type.GetProperty("ImagePath" + imgNum++.ToString());
					//imgProp.SetValue(phone, path);
				}
			}
			int id = 1;
			foreach (var val in values)
			{
				var characteristic = dbContext.Characteristics.FirstOrDefault(c => c.Id == id);
				id++;
				Example phoneExample = new Example() { Characteristic = characteristic, Value = val };
				dbContext.Examples.Add(phoneExample);
				dbContext.PhoneExamples.Add(new PhoneExample() { Phone = phone, Example = phoneExample });
			}
			//}
			await dbContext.SaveChangesAsync();
			return View(characteristics);
		}
	}
}
