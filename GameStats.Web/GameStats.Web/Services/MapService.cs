using GameStats.Web.Components.Pages.Game;
using GameStats.Web.Components.Pages.Map;
using GameStats.Web.Models;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class MapService : IMapService
{
    private static IEnumerable<MapModel> maps = [];

    public Task<IEnumerable<MapModel>> GetMapsAsync()
    {
        return Task.FromResult(maps);
    }

    public Task<MapModel> CreateMapAsync(MapModel map)
    {
        var add = new MapModel
        {
            MapId = maps.Count() > 0 ? maps.Max(m => m.MapId) + 1 : 1,
            GameId = map.GameId,
            MapName = map.MapName
        };

        var list = maps.ToList();

        list.Add(add);

        maps = list;

        return Task.FromResult(add);
    }

    public Task<MapModel> UpdateMapAsync(MapModel map)
    {
        var edit = maps.FirstOrDefault(m => m.MapId == map.MapId);

        if (edit != null)
        {
            edit.MapName = map.MapName;
            edit.GameId = map.GameId;
        }

        return Task.FromResult(map);
    }

    public Task DeleteMapAsync(int mapId)
    {
        var delete = maps.FirstOrDefault(m => m.MapId == mapId);

        if (delete != null)
        {
            var list = maps.ToList();

            list.Remove(delete);

            maps = list;
        }

        return Task.FromResult(true);
    }
}
