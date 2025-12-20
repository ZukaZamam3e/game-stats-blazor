using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IMatchService
{
    Task<DataResponse<MatchModel>> GetMatchesAsync(int take, int offset);
    Task<MatchModel> CreateMatchAsync(MatchModel match);
    Task<MatchModel> UpdateMatchAsync(MatchModel match);
    Task<bool> DeleteMatchAsync(int matchId);
}
