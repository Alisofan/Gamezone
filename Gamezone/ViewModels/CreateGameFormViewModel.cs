

using System.Runtime.CompilerServices;
using GameZone.Attributes;

namespace GameZone.ViewModels
{
	public class CreateGameFormViewModel
	{
		[MaxLength(length: 250)]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

		[Display(Name = "SupportedSDevices")]
		public List<int> SelectedDevices { get; set; } = default!;

		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

		[MaxLength(length: 2500)]
		public string Description { get; set; } = string.Empty;
		[AllowedExtensions(FileSettings.AllowedExtensions),
			MaxFileSize(FileSettings.MaxFileSizeInBytes)]
		public IFormFile Cover { get; set; } = default!;
	}
}
