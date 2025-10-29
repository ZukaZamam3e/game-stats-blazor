using GameStats.Web.Models;

namespace GameStats.Web.Services.Interfaces;

public interface IGameService
{
    Task<IEnumerable<GameModel>> GetGamesAsync();
    Task<GameModel> CreateGameAsync(GameModel game);
    Task<GameModel> UpdateGameAsync(GameModel game);
    Task<bool> DeleteGameAsync(int gameId);
}
