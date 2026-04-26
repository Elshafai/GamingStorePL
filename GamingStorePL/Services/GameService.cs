using BLL.Interfaces;
using BLL.Repositories;
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
    }
}
