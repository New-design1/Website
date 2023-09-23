using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
				SaveImages(phone);
			}

			int characteristicId = 1;
			foreach (var value in values)
			{
				Characteristic? characteristic = dbContext.Characteristics.FirstOrDefault(c => c.Id == characteristicId);
				Example? ExampleFromDb = dbContext.Examples.FirstOrDefault(x => x.CharacteristicId == characteristicId && x.Value == value);
				if (ExampleFromDb == default(Example))
				{
					Example example = new Example() { Characteristic = characteristic, Value = value };
					dbContext.Examples.Add(example);
					dbContext.PhoneExamples.Add(new PhoneExample() { Phone = phone, Example = example });
				}
				else
				{
					dbContext.PhoneExamples.Add(new PhoneExample() { Phone = phone, Example = ExampleFromDb });
				}
				characteristicId++;
			}
			await dbContext.SaveChangesAsync();
			return View(characteristics);
		}


		public IActionResult RemovePhone()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RemovePhone(string modelName)
		{
			Phone? phone = dbContext.Phones.FirstOrDefault(x => x.ModelName == modelName);
			if (phone != null)
			{
				dbContext.Phones.Remove(phone);
				await dbContext.SaveChangesAsync();
				ViewData["Message"] = $"{modelName} успешно удален";
			}
			return View();
		}

		public async Task<IActionResult> UpdatePhone(string modelName)
		{
			if (modelName == null)
				return View();
			Phone? phone = dbContext.Phones.FirstOrDefault(x => x.ModelName == modelName);
			if (phone == null)
			{
				ViewData["Message"] = $"{modelName} нет в бд";
				return View();
			}
			phone = dbContext.Phones
				.Include(p => p.PhoneExamples)
				.ThenInclude(p => p.Example)
				.ThenInclude(p => p.Characteristic)
				.Include(p => p.PhoneImages)
				.ThenInclude(p => p.Image)
				.FirstOrDefault(p => p.ModelName == modelName);
			return View(phone);
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePhone(Phone phone, params string[] values)
		{
			Phone? phoneFromDb = dbContext.Phones
										.Include(p => p.PhoneExamples)
										.ThenInclude(p => p.Example)
										.ThenInclude(p => p.Characteristic)
										.Include(p => p.PhoneImages)
										.ThenInclude(p => p.Image)
										.FirstOrDefault(p => p.ModelName == phone.ModelName);
			phoneFromDb.ModelName = phone.ModelName;

			if (Request.Form.Files.Count != 0)
			{
				phoneFromDb.PhoneImages.RemoveAll(x => true);
				SaveImages(phone);
			}
			// 1. Получили значение характеристики телефона из формы
			// 2. Сравниваем полученную хар-ку с имеющейся
			// 3. Если совпадает, то ничего не делаем
			// 4. Если не совпадает, то удаляем запись из таблицы phoneExamples, ищем есть ли уже такая запись в таблице. Если есть, ставим ее, нет - добавляем новую

			int rowIndex = 0;
			int characteristicId = 1;
			foreach (var value in values)
			{
				var example2 = phoneFromDb.PhoneExamples[rowIndex].Example;
				if (example2.CharacteristicId == characteristicId && example2.Value == value)
					continue;

				Example exampleFromDb = dbContext.Examples.FirstOrDefault(x => x.CharacteristicId == characteristicId && x.Value == value);
				if (exampleFromDb == default(Example))
					example2.Value = value;
				else
				{
					phoneFromDb.PhoneExamples[rowIndex].Example = exampleFromDb;
				}

				characteristicId++;
				rowIndex++;
			}
			await dbContext.SaveChangesAsync();
			ViewData["Updated"] = $"Хараткеристики телефона {phone.ModelName} успешно обновлены";
			return View();
		}

		[NonAction]
		private void SaveImages(Phone phone)
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
					dbContext.PhoneImages.Add(new PhoneImage { Phone = phone, Image = imageFromDb });
				}
			}
		}
	}
}
