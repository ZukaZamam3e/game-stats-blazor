using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IPlayerService
{
    Task<DataResponse<PlayerModel>> GetPlayersAsync(int take, int offset);
    Task<PlayerModel> CreatePlayerAsync(PlayerModel player);
    Task<PlayerModel> UpdatePlayerAsync(PlayerModel player);
    Task<bool> DeletePlayerAsync(int playerId);
}
