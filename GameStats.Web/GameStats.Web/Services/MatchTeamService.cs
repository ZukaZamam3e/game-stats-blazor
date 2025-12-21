using GameStats.Web.Models;
using GameStats.Web.Models.Responses;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class MatchTeamService(IHttpClientFactory httpClientFactory) : IMatchTeamService, IDisposable
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Constants.GameStatsWebAPIClient);
    private const string matchTeamDataRoute = "api/matchteam/data";
    private const string matchTeamCreateRoute = "api/matchteam/create";
    private const string matchTeamUpdateRoute = "api/matchteam/update";
    private const string matchTeamDeleteRoute = "api/matchteam/delete";

    public async Task<DataResponse<MatchTeamModel>> GetMatchTeamsAsync(int take, int offset, int? matchTeamId = null, int? matchId = null, string? teamColor = null)
    {
        string query = $"?take={take}&offset={offset}";
        var httpResponse = await httpClient.GetAsync(matchTeamDataRoute + query);
        var response = await httpResponse.ParseResponseAsync<DataResponse<MatchTeamModel>>();
        return response;
    }

    public async Task<MatchTeamModel> CreateMatchTeamAsync(MatchTeamModel matchTeam)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchTeamCreateRoute, matchTeam);
        var response = await httpResponse.ParseResponseAsync<MatchTeamModel>();
        return response;
    }

    public async Task<MatchTeamModel> UpdateMatchTeamAsync(MatchTeamModel matchTeam)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchTeamUpdateRoute, matchTeam);
        var response = await httpResponse.ParseResponseAsync<MatchTeamModel>();
        return response;
    }

    public async Task<bool> DeleteMatchTeamAsync(int matchTeamId)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchTeamDeleteRoute, new { matchTeamId });
        var response = await httpResponse.ParseResponseAsync<DeleteResponse>();
        return response.Success;
    }

    public void Dispose() => httpClient.Dispose();
}
