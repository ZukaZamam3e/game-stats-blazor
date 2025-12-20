using GameStats.Web.Models;

namespace GameStats.Web.Services.Interfaces;

public interface IMapService
{
    Task<IEnumerable<MapModel>> GetMapsAsync();
    Task<MapModel> CreateMapAsync(MapModel map);
    Task<MapModel> UpdateMapAsync(MapModel map);
    Task<bool> DeleteMapAsync(int mapId);
}
