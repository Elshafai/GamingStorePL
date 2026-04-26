using DAL.Models;
using GamingStorePL.Attribute;
using GamingStorePL.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GamingStorePL.ViewModels
{
    public class CreateGameVM
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;
        [AllowedExtension(FileSettings.AllowedExtensions), MaxSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile CoverImage { get; set; } = default!;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Selected Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        //public static explicit operator CreateGameVM(Game game)
        //{
        //    return new CreateGameVM
        //    {
        //        Name = game.Name,
        //        Description = game.Description,
        //        Price = game.Price,
        //        Quantity = game.Quantity,
        //        Cover = game.Cover,
        //        CategoryId = game.CategoryId,
        //        SelectedDevices = game.GameDevices
        //        .Select(gd => gd.DeviceId)
        //        .ToList()
        //    };
        //}
        //public static explicit operator Game(CreateGameVM game)
        //{
        //    if (game.CoverImage is not null)
        //        game.Cover = DocumentSettings.UploadeFile(game.CoverImage);
            
        //    return new Game
        //    {
        //        Name = game.Name,
        //        Description = game.Description,
        //        Price = game.Price,
        //        Quantity = game.Quantity,
        //        Cover = string.IsNullOrEmpty(game.Cover) ? null : game.Cover,
        //        CategoryId = game.CategoryId,
        //        GameDevices = game.SelectedDevices
        //            .Select(id => new GameDevice
        //            {
        //                DeviceId = id
        //            }).ToList()
        //    };
        //}
    }
}

