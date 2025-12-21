using GameStats.Web.Models;
using GameStats.Web.Models.Responses;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class MatchPlayerService(IHttpClientFactory httpClientFactory) : IMatchPlayerService, IDisposable
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Constants.GameStatsWebAPIClient);
    private const string matchPlayerDataRoute = "api/matchplayer/data";
    private const string matchPlayerCreateRoute = "api/matchplayer/create";
    private const string matchPlayerUpdateRoute = "api/matchplayer/update";
    private const string matchPlayerDeleteRoute = "api/matchplayer/delete";
    public async Task<DataResponse<MatchPlayerModel>> GetMatchPlayersAsync(int take, int offset, int? matchPlayerId = null, int? matchId = null, int? playerId = null, int? matchTeamId = null)
    {
        string query = $"?take={take}&offset={offset}";
        if (matchPlayerId.HasValue)
            query += $"&matchPlayerId={matchPlayerId.Value}";
        if (matchId.HasValue)
            query += $"&matchId={matchId.Value}";
        if (playerId.HasValue)
            query += $"&playerId={playerId.Value}";
        if (matchTeamId.HasValue)
            query += $"&matchTeamId={matchTeamId.Value}";

        var httpResponse = await httpClient.GetAsync(matchPlayerDataRoute + query);
        var response = await httpResponse.ParseResponseAsync<DataResponse<MatchPlayerModel>>();
        return response;
    }
    public async Task<MatchPlayerModel> CreateMatchPlayerAsync(MatchPlayerModel matchPlayer)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchPlayerCreateRoute, matchPlayer);
        var response = await httpResponse.ParseResponseAsync<MatchPlayerModel>();
        return response;
    }
    public async Task<MatchPlayerModel> UpdateMatchPlayerAsync(MatchPlayerModel matchPlayer)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchPlayerUpdateRoute, matchPlayer);
        var response = await httpResponse.ParseResponseAsync<MatchPlayerModel>();
        return response;
    }
    public async Task<bool> DeleteMatchPlayerAsync(int matchPlayerId)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(matchPlayerDeleteRoute, new { matchPlayerId });
        var response = await httpResponse.ParseResponseAsync<DeleteResponse>();
        return response.Success;
    }
    public void Dispose() => httpClient.Dispose();
}
