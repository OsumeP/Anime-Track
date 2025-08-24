using System.Collections;
using AnimeTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeTrack.Entity;

public class AnimeContext: DbContext
{
    public DbSet<Anime> Animes {get;set;}

    public AnimeContext(DbContextOptions<AnimeContext> options) :base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Anime> iAnimes = new List<Anime>() {
        new Anime
            {
                id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                name = "Blue Lock S1",
                totalEpisodes = 24,
                totalWatched = 24,
                state = ViewState.Finished,
            }
        , new Anime{
            id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfc8ef"),
            name = "Konosuba S1",
            totalEpisodes = 12,
            totalWatched = 12,
            state = ViewState.Finished,
        }
        };

        modelBuilder.Entity<Anime>(anime =>
        {
            anime.ToTable("Anime");

            anime.HasKey(a => a.id);
            anime.Property(a => a.name);
            anime.Property(a => a.img);
            anime.Property(a => a.totalEpisodes);
            anime.Property(a => a.totalWatched);

            anime.HasData(iAnimes);

        });
    }

}