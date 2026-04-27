using BLL.Interfaces;
using BLL.Repositories;
using BLL.Specification;
using DAL.Models;
using GamingStorePL.Helper;
using GamingStorePL.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamingStorePL.Services
{
    public class GameService : IGameService
    {
        private readonly IUniteOfWork uniteOfWork;

        public GameService(IUniteOfWork uniteOfWork)
        {
            this.uniteOfWork = uniteOfWork;
        }
        public void CreateGame(CreateGameVM model)
        {
            string fileName = string.Empty;

            if (model.CoverImage != null && model.CoverImage.Length > 0)
                fileName = DocumentSettings.UploadeFile(model.CoverImage);
            var game = new Game
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                Cover = fileName,
                CategoryId = model.CategoryId,
                GameDevices = model.SelectedDevices?
                    .Select(id => new GameDevice { DeviceId = id })
                    .ToList() ?? new List<GameDevice>()
            };
            uniteOfWork.GetGenericRepo<Game>().Create(game);
            uniteOfWork.Complete();
        }
        public CreateGameVM PrepareCreateGameVM()
        {
            return new CreateGameVM
            {
                Categories = uniteOfWork
                .GetGenericRepo<Category>()
                .GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }),
                Devices = uniteOfWork
                .GetGenericRepo<Device>()
                .GetAll()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
            };
        }
        public IEnumerable<GameVM> GetAllGames()
        {
            var spec = new GameWithCategoryAndDevicesSpec();
            var games = uniteOfWork.GetGenericRepo<Game>().GetAllWithSpec(spec);

            return games.Select(g => new GameVM
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Price = g.Price,
                Quantity = g.Quantity,
                Cover = g.Cover,
                Category = g.Category.Name,
                Devices = g.GameDevices.Select(gd => gd.Device.Name)
            });
        }
        public GameVM? GetGameById(int id)
        {
            var spec = new GameWithCategoryAndDevicesSpec(id);
            var game = uniteOfWork.GetGenericRepo<Game>().GetWithSpec(spec);

            if (game is null) return null;

            return new GameVM
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                Quantity = game.Quantity,
                Cover = game.Cover,
                Category = game.Category.Name,
                Devices = game.GameDevices.Select(gd => gd.Device.Name)
            };
        }
        public EditGameVM? PrepareEditGameVM(int id)
        {
            var spec = new GameWithCategoryAndDevicesSpec(id);
            var game = uniteOfWork.GetGenericRepo<Game>().GetWithSpec(spec);

            if (game is null) return null;

            return new EditGameVM
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                Quantity = game.Quantity,
                CurrentCover = game.Cover,
                CategoryId = game.CategoryId,
                SelectedDevices = game.GameDevices.Select(gd => gd.DeviceId).ToList(),
                Categories = uniteOfWork.GetGenericRepo<Category>().GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }),
                Devices = uniteOfWork.GetGenericRepo<Device>().GetAll()
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    })
            };
        }

        public void UpdateGame(EditGameVM model)
        {
            var spec = new GameWithCategoryAndDevicesSpec(model.Id);
            var game = uniteOfWork.GetGenericRepo<Game>().GetWithSpec(spec);

            if (game is null) return;

            // handle cover
            if (model.CoverImage != null && model.CoverImage.Length > 0)
            {
                // حذف القديم
                if (!string.IsNullOrEmpty(game.Cover))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(),
                        FileSettings.CoverPath, game.Cover);
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }
                game.Cover = DocumentSettings.UploadeFile(model.CoverImage);
            }

            game.Name = model.Name;
            game.Description = model.Description;
            game.Price = model.Price;
            game.Quantity = model.Quantity;
            game.CategoryId = model.CategoryId;

            // update devices
            game.GameDevices = model.SelectedDevices
                .Select(id => new GameDevice { GameId = game.Id, DeviceId = id })
                .ToList();

            uniteOfWork.GetGenericRepo<Game>().Update(game);
            uniteOfWork.Complete();
        }
        public void DeleteGame(int id)
        {
            var game = uniteOfWork.GetGenericRepo<Game>().Get(id);

            if (game is null) return;

            // حذف الصورة
            if (!string.IsNullOrEmpty(game.Cover))
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    FileSettings.CoverPath, game.Cover);
                if (File.Exists(path))
                    File.Delete(path);
            }

            uniteOfWork.GetGenericRepo<Game>().Delete(game);
            uniteOfWork.Complete();
        }
    }
}
