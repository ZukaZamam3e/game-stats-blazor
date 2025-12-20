using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IMatchTypeService
{
    Task<DataResponse<MatchTypeModel>> GetMatchTypesAsync(int take, int offset);
    Task<MatchTypeModel> CreateMatchTypeAsync(MatchTypeModel matchType);
    Task<MatchTypeModel> UpdateMatchTypeAsync(MatchTypeModel matchType);
    Task<bool> DeleteMatchTypeAsync(int matchTypeId);
}
