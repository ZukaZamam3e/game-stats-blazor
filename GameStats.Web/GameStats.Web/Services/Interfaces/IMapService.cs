using GameStats.Web.Models;
using GameStats.Web.Models.Responses;

namespace GameStats.Web.Services.Interfaces;

public interface IMapService
{
    Task<DataResponse<MapModel>> GetMapsAsync(int take, int offset);
    Task<MapModel> CreateMapAsync(MapModel map);
    Task<MapModel> UpdateMapAsync(MapModel map);
    Task<bool> DeleteMapAsync(int mapId);
}
