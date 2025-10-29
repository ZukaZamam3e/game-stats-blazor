using GameStats.Web.Components.Pages.Game;
using GameStats.Web.Models;
using GameStats.Web.Models.Responses;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class GameService(IHttpClientFactory httpClientFactory) : IGameService, IDisposable
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Constants.GameStatsWebAPIClient);
    private const string gameDataRoute = "api/game/data";
    private const string gameCreateRoute = "api/game/create";
    private const string gameUpdateRoute = "api/game/update";
    private const string gameDeleteRoute = "api/game/delete";

    public async Task<IEnumerable<GameModel>> GetGamesAsync()
    {
        var httpResponse = await httpClient.GetAsync(gameDataRoute);
        var response = await httpResponse.ParseResponseAsync<GetGamesResponse>();
        return response.Games;
    }

    public async Task<GameModel> CreateGameAsync(GameModel game)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(gameCreateRoute, game);
        var response = await httpResponse.ParseResponseAsync<GameModel>();
        return response;
    }

    public async Task<GameModel> UpdateGameAsync(GameModel game)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(gameUpdateRoute, game);
        var response = await httpResponse.ParseResponseAsync<GameModel>();
        return response;
    }

    public async Task<bool> DeleteGameAsync(int gameId)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(gameDeleteRoute, new { gameId });
        var response = await httpResponse.ParseResponseAsync<DeleteResponse>();
        return response.Success;
    }

    public void Dispose() => httpClient.Dispose();
}
