namespace GameStats.Web.Models.Responses;

public sealed record DataResponse<T>(IEnumerable<T> Data, int Count);
