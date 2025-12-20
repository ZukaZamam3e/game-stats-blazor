using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IGameService
{
    Task<DataResponse<GameModel>> GetGamesAsync(int take, int offset);
    Task<GameModel> CreateGameAsync(GameModel game);
    Task<GameModel> UpdateGameAsync(GameModel game);
    Task<bool> DeleteGameAsync(int gameId);
}
