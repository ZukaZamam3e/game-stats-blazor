using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IMatchPlayerService
{
    Task<DataResponse<MatchPlayerModel>> GetMatchPlayersAsync(int take, int offset, int? matchPlayerId = null, int? matchId = null, int? playerId = null, int ? matchTeamId = null);
    Task<MatchPlayerModel> CreateMatchPlayerAsync(MatchPlayerModel matchPlayer);
    Task<MatchPlayerModel> UpdateMatchPlayerAsync(MatchPlayerModel matchPlayer);
    Task<bool> DeleteMatchPlayerAsync(int matchPlayerId);
}
