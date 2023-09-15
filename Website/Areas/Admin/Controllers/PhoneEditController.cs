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
			var phoneFromDb = dbContext.Phones.FirstOrDefault(x => x.ModelName == phone.ModelName);
			if (!(phoneFromDb == default(Phone)))
			{
				ViewData["PhoneId"] = phoneFromDb.Id;
				ViewData["PhoneModelName"] = phoneFromDb.ModelName;
				return View(characteristics);
			}
			dbContext.Phones.Add(phone);

			if (Request.Form.Files != null)
			{
				
				foreach (var imageFromForm in Request.Form.Files)
				{
					using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/phones/", imageFromForm.FileName), FileMode.Create))
					{
						imageFromForm.CopyTo(stream);
					}

					string path = Path.Combine("/images/phones/", imageFromForm.FileName);
					var imageFromDb = dbContext.Images.FirstOrDefault(x => x.Path == path);

					if (imageFromDb == default(Image))
					{
						Image image = new Image() { Path = path };
						dbContext.Images.Add(image);
						dbContext.PhoneImages.Add(new PhoneImage() { Phone = phone, Image = image });
					}
					else
					{
						dbContext.PhoneImages.Add(new PhoneImage { Phone = phone, Image =  imageFromDb});
					}
				}
			}

			int characteristicId = 1;
			foreach (var value in values)
			{
				Characteristic characteristic = dbContext.Characteristics.FirstOrDefault(c => c.Id == characteristicId);
				Example phoneExampleFromDb = dbContext.Examples.FirstOrDefault(x => x.CharacteristicId == characteristicId && x.Value == value);
				if (phoneExampleFromDb == default(Example))
				{
					Example phoneExample = new Example() { Characteristic = characteristic, Value = value };
					dbContext.Examples.Add(phoneExample);
					dbContext.PhoneExamples.Add(new PhoneExample() { Phone = phone, Example = phoneExample });
				}
				else
				{
					dbContext.PhoneExamples.Add(new PhoneExample() { Phone = phone, Example = phoneExampleFromDb });
				}	
				characteristicId++;
			}
			//}
			await dbContext.SaveChangesAsync();
			return View(characteristics);
		}
	}
}
