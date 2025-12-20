using GameStats.Web.Models;
using GameStats.Web.Models.Responses;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class MatchService(IHttpClientFactory httpClientFactory) : IMatchService, IDisposable
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Constants.GameStatsWebAPIClient);
    private const string matchDataRoute = "api/match/data";
    private const string matchCreateRoute = "api/match/create";
    private const string matchUpdateRoute = "api/match/update";
    private const string matchDeleteRoute = "api/match/delete";

    public async Task<DataResponse<MatchModel>> GetMatchesAsync(int take, int offset)
    {
        string query = $"?take={take}&offset={offset}";
        var httpResponse = await httpClient.GetAsync(matchDataRoute + query);
        var response = await httpResponse.ParseResponseAsync<DataResponse<MatchModel>>();
        return response;
    }

    public async Task<MatchModel> CreateMatchAsync(MatchModel match)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchCreateRoute, match);
        var response = await httpResponse.ParseResponseAsync<MatchModel>();
        return response;
    }

    public async Task<MatchModel> UpdateMatchAsync(MatchModel match)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchUpdateRoute, match);
        var response = await httpResponse.ParseResponseAsync<MatchModel>();
        return response;
    }

    public async Task<bool> DeleteMatchAsync(int matchId)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchDeleteRoute, new { matchId });
        var response = await httpResponse.ParseResponseAsync<DeleteResponse>();
        return response.Success;
    }

    public void Dispose() => httpClient.Dispose();
}
