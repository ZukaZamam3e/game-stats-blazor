using GameStats.Web.Components.Pages.Game;
using GameStats.Web.Components.Pages.Map;
using GameStats.Web.Models;
using GameStats.Web.Models.Responses;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class MapService(IHttpClientFactory httpClientFactory) : IMapService, IDisposable
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Constants.GameStatsWebAPIClient);
    private const string mapDataRoute = "api/map/data";
    private const string mapCreateRoute = "api/map/create";
    private const string mapUpdateRoute = "api/map/update";
    private const string mapDeleteRoute = "api/map/delete";

    public async Task<IEnumerable<MapModel>> GetMapsAsync()
    {
        var httpResponse = await httpClient.GetAsync(mapDataRoute);
        var response = await httpResponse.ParseResponseAsync<GetMapsResponse>();
        return response.Maps;
    }

    public async Task<MapModel> CreateMapAsync(MapModel map)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(mapCreateRoute, map);
        var response = await httpResponse.ParseResponseAsync<MapModel>();
        return response;
    }

    public async Task<MapModel> UpdateMapAsync(MapModel map)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(mapUpdateRoute, map);
        var response = await httpResponse.ParseResponseAsync<MapModel>();
        return response;
    }

    public async Task<bool> DeleteMapAsync(int mapId)
    {
        var httpResponse = await httpClient.PostAsJsonAsync(mapDeleteRoute, new { mapId });
        var response = await httpResponse.ParseResponseAsync<DeleteResponse>();
        return response.Success;
    }

    public void Dispose() => httpClient.Dispose();

}
