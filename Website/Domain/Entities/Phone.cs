using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Entities
{
	public class Phone
	{
		[Required]
		public Guid Id { get; set; }
		public string? ModelName { get; set; }
	}

	public class Image
	{
		[Required]
		public int Id { get; set; }
		public string? Path { get; set; }
	}

	public class PhoneImage
	{
		[Required]
		public int Id { get; set; }
		public Guid PhoneId { get; set; }
		public int ImageId { get; set; }
		public Phone? Phone { get; set; }
		public Image? Image { get; set; }
	}

	public class Characteristic
	{
		[Required]
		public int Id { get; set; }
		public string? Name { get; set; }
	}

	public class Example
	{
		[Required]
		public int Id { get; set; }
		public int CharacteristicId { get; set; }
		public Characteristic? Characteristic { get; set; }
		public string? Value { get; set; }
	}

	public class PhoneExample
	{
		[Required]
		public int Id { get; set; }
		public Guid PhoneId { get; set; }
		public int ExampleId { get; set; }
		public Phone? Phone { get; set; }
		public Example? Example { get; set; }
	}
}
