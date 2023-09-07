using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Entities
{
	public class Phone
	{
		[Required]
		public Guid Id { get; set; }
		public string? ImagePath1 { get; set; }
		public string? ImagePath2 { get; set; }
		public string? ImagePath3 { get; set; }
		public string? ImagePath4 { get; set; }
		public string? ImagePath5 { get; set; }
		public string? ModelName { get; set; }
		public string? Color { get; set; }
		public string? ScreenDiagonal { get; set; }
		public string? Resolution { get; set; }
		public string? ScreenFrequency { get; set;}
		public string? OperatingSystem { get; set;}
		public string? ProcessorModel { get; set; }
		public string? CoresCount { get; set; }
		public string? CoreFrequency { get; set; }
		public string? BatteryCapacity { get; set; }
		public string? Price { get; set; }
	}
}
