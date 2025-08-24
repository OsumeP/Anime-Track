namespace AnimeTrack.Models;

public class Anime
{
    public Guid id { get; set; }
    public string name { get; set; }
    public int totalEpisodes { get; set; }
    public int totalWatched { get; set; }
    public string? img { get; set; }
    public ViewState state { get; set; }
}

public enum ViewState
{
    Finished,
    Watching,
    NotStarted,
    Dropped,
    Pending
}