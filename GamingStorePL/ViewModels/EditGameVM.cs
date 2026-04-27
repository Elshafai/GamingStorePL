using GamingStorePL.Attribute;
using GamingStorePL.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GamingStorePL.ViewModels
{
    public class EditGameVM
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? CurrentCover { get; set; }
        [AllowedExtension(FileSettings.AllowedExtensions), MaxSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? CoverImage { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Selected Devices")]
        public List<int> SelectedDevices { get; set; } = new();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
