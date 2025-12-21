using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IMatchTeamService
{
    Task<DataResponse<MatchTeamModel>> GetMatchTeamsAsync(int take, int count, int? matchTeamId = null, int? matchId = null, string? teamColor = null);
    Task<MatchTeamModel> CreateMatchTeamAsync(MatchTeamModel matchTeam);
    Task<MatchTeamModel> UpdateMatchTeamAsync(MatchTeamModel matchTeam);
    Task<bool> DeleteMatchTeamAsync(int matchTeamId);
}
