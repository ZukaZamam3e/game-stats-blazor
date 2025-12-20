using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IMatchTypeService
{
    Task<DataResponse<MatchTypeModel>> GetMatchTypesAsync(int take, int offset, int? matchTypeId = null, string? matchTypeName = null, int? gameId = null);
    Task<MatchTypeModel> CreateMatchTypeAsync(MatchTypeModel matchType);
    Task<MatchTypeModel> UpdateMatchTypeAsync(MatchTypeModel matchType);
    Task<bool> DeleteMatchTypeAsync(int matchTypeId);
}
