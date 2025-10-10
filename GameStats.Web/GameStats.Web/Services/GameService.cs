using GameStats.Web.Components.Pages.Game;
using GameStats.Web.Models;
using GameStats.Web.Services.Interfaces;

namespace GameStats.Web.Services;

public class GameService : IGameService
{
    private static IEnumerable<GameModel> games = [.. Enumerable.Range(1, 5).Select(index => new GameModel
    {
        GameId = index,
        GameName = $"Halo {index}",
    })];

    public Task<IEnumerable<GameModel>> GetGamesAsync()
    {
        return Task.FromResult(games);
    }

    public Task<GameModel> CreateGameAsync(GameModel game)
    {
        var add = new GameModel
        {
            GameId = games.Count() > 0 ? games.Max(m => m.GameId) + 1 : 1,
            GameName = game.GameName
        };

        var list = games.ToList();

        list.Add(add);

        games = list;

        return Task.FromResult(add);
    }

    public Task<GameModel> UpdateGameAsync(GameModel game)
    {
        var edit = games.FirstOrDefault(m => m.GameId == game.GameId);

        if(edit != null)
        {
            edit.GameName = game.GameName;
        }

        return Task.FromResult(game);
    }

    public Task DeleteGameAsync(int gameId)
    {
        var delete = games.FirstOrDefault(m => m.GameId == gameId);

        if(delete != null)
        {
            var list = games.ToList();

            list.Remove(delete);

            games = list;
        }

        return Task.FromResult(true);
    }
}
