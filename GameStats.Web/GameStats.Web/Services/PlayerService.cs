using GameStats.Web.Components.Pages.Map;
using GameStats.Web.Components.Pages.Player;
using GameStats.Web.Models;
using GameStats.Web.Models.Responses;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class PlayerService(IHttpClientFactory httpClientFactory) : IPlayerService, IDisposable
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Constants.GameStatsWebAPIClient);
    private const string playerDataRoute = "api/player/data";
    private const string playerCreateRoute = "api/player/create";
    private const string playerUpdateRoute = "api/player/update";
    private const string playerDeleteRoute = "api/player/delete";



    public async Task<DataResponse<PlayerModel>> GetPlayersAsync(int take, int offset)
    {
        string query = $"?take={take}&offset={offset}";
        var httpResponse = await httpClient.GetAsync(playerDataRoute + query);
        var response = await httpResponse.ParseResponseAsync<DataResponse<PlayerModel>>();
        return response;
    }

    public async Task<PlayerModel> CreatePlayerAsync(PlayerModel player)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(playerCreateRoute, player);
        var response = await httpResponse.ParseResponseAsync<PlayerModel>();
        return response;
    }

    public async Task<PlayerModel> UpdatePlayerAsync(PlayerModel player)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(playerUpdateRoute, player);
        var response = await httpResponse.ParseResponseAsync<PlayerModel>();
        return response;
    }

    public async Task<bool> DeletePlayerAsync(int playerId)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(playerDeleteRoute, new { playerId });
        var response = await httpResponse.ParseResponseAsync<DeleteResponse>();
        return response.Success;
    }

    public void Dispose() => httpClient.Dispose();
}
