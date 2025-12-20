namespace GameStats.Web.Models;

public class PlayerModel
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int GameId { get; set; }
    public string Emblem { get; set; } = "emblem";
}
