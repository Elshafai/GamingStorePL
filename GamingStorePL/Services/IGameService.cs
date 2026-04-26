using GamingStorePL.ViewModels;

namespace GamingStorePL.Services
{
    public interface IGameService
    {
        CreateGameVM PrepareCreateGameVM();
        void CreateGame(CreateGameVM model);

    }
}
