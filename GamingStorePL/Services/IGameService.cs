using GamingStorePL.ViewModels;

namespace GamingStorePL.Services
{
    public interface IGameService
    {
        CreateGameVM PrepareCreateGameVM();
        void CreateGame(CreateGameVM model);
        IEnumerable<GameVM> GetAllGames();
        GameVM? GetGameById(int id);
        EditGameVM? PrepareEditGameVM(int id);
        void UpdateGame(EditGameVM model);
        void DeleteGame(int id);
    }
}
