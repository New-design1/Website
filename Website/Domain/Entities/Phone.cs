using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Entities
{
	[Index(nameof(ModelName), IsUnique = true)]
	public class Phone
	{
		[Required]
		public Guid Id { get; set; }
		public string? ModelName { get; set; }
		public List<PhoneImage> PhoneImages { get; set; } = new();
		public List<PhoneExample> PhoneExamples { get; set; } = new();
	}

	[Index(nameof(Path), IsUnique = true)]
	public class Image
	{
		[Required]
		public int Id { get; set; }
		public string? Path { get; set; }
		public List<PhoneImage> PhoneImages { get; set; } = new();
	}

	public class PhoneImage
	{
		[Required]
		public int Id { get; set; }
		public Guid PhoneId { get; set; }
		public Phone? Phone { get; set; }
		public int ImageId { get; set; }
		public Image? Image { get; set; }
	}

	public class Characteristic
	{
		[Required]
		public int Id { get; set; }
		public string? Name { get; set; }
		public List<Example> Examples { get; set; } = new();
	}

	[Index(nameof(CharacteristicId), nameof(Value), IsUnique = true)]
	public class Example
	{
		[Required]
		public int Id { get; set; }
		public int CharacteristicId { get; set; }
		public Characteristic? Characteristic { get; set; }
		public string? Value { get; set; }
		public List<PhoneExample> PhoneExamples { get; set; } = new();
	}

	public class PhoneExample
	{
		[Required]
		public int Id { get; set; }
		public Guid PhoneId { get; set; }
		public Phone? Phone { get; set; }
		public int ExampleId { get; set; }
		public Example? Example { get; set; }
	}
}
