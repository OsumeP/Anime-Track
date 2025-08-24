using AnimeTrack.Models;
using AnimeTrack.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
namespace AnimeTrack.Services;

public interface IAnimeService
{
    public IEnumerable<Anime> getAnimes();
    public Task<Anime?> getAnimeId(Guid id);
    public Task<Message> deleteAnime(Guid id);
    public Task<Message> updateAnime(Guid id, Anime anime);
    public Task<Message> createAnime(Anime anime);
}

public class AnimeService : IAnimeService
{
    AnimeContext context;

    public AnimeService(AnimeContext dbContext)
    {
        this.context = dbContext;    
    }

    public IEnumerable<Anime> getAnimes()
    {
        return  context.Animes;
    }

    public async  Task<Anime?> getAnimeId(Guid id)
    {
        return await context.Animes.FindAsync(id);
    }

    public async Task<Message> deleteAnime(Guid id)
    {
        var obj = await context.Animes.FindAsync(id);
        if (obj == null) return new Message(false, "No register with the specified Id");
        context.Remove(obj);
        await context.SaveChangesAsync();
        return new Message(true, "Process completed");
    }

    public async Task<Message> updateAnime(Guid id, Anime anime)
    {
        var obj = await context.Animes.FindAsync(id);
        if (obj == null) return new Message(false, "No register with the specified Id");
        if (anime.totalEpisodes < anime.totalWatched) return new Message(false, "Invalid fields values");
        obj.name = anime.name;
        obj.totalEpisodes = anime.totalEpisodes;
        obj.totalWatched = anime.totalWatched;
        obj.state = anime.state;

        await context.SaveChangesAsync();

        return new Message(true, "Process completed");
    }

    public async Task<Message> createAnime(Anime anime)
    {
        if (anime.totalEpisodes < anime.totalWatched) return new Message(false, "Invalid fields values");
        context.Animes.Add(anime);
        await context.SaveChangesAsync();

        return new Message(true, "Process completed");
    }

}