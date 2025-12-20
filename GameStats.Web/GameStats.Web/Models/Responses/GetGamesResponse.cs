namespace GameStats.Web.Models.Responses;

public class GetGamesResponse
{
    public required IEnumerable<GameModel> Games { get; set; }
}
