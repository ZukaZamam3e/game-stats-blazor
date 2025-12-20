using GameStats.Web.Models;
using GameStats.Web.Models.Responses;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class MatchTypeService(IHttpClientFactory httpClientFactory) : IMatchTypeService, IDisposable
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Constants.GameStatsWebAPIClient);
    private const string matchTypeDataRoute = "api/matchType/data";
    private const string matchTypeCreateRoute = "api/matchType/create";
    private const string matchTypeUpdateRoute = "api/matchType/update";
    private const string matchTypeDeleteRoute = "api/matchType/delete";

    public async Task<DataResponse<MatchTypeModel>> GetMatchTypesAsync(int take, int offset)
    {
        string query = $"?take={take}&offset={offset}";
        var httpResponse = await httpClient.GetAsync(matchTypeDataRoute + query);
        var response = await httpResponse.ParseResponseAsync<DataResponse<MatchTypeModel>>();
        return response;
    }

    public async Task<MatchTypeModel> CreateMatchTypeAsync(MatchTypeModel matchType)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchTypeCreateRoute, matchType);
        var response = await httpResponse.ParseResponseAsync<MatchTypeModel>();
        return response;
    }

    public async Task<MatchTypeModel> UpdateMatchTypeAsync(MatchTypeModel matchType)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchTypeUpdateRoute, matchType);
        var response = await httpResponse.ParseResponseAsync<MatchTypeModel>();
        return response;
    }

    public async Task<bool> DeleteMatchTypeAsync(int matchTypeId)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchTypeDeleteRoute, new { matchTypeId });
        return httpResponse.IsSuccessStatusCode;
    }

    public void Dispose() => httpClient.Dispose();
}
