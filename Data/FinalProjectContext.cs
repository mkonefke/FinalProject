using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FinalProject.Models.VideoGame> VideoGame { get; set; } = default!;
        public DbSet<FinalProject.Models.Platform> Platform { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = "PC" },
                new Platform { Id = 2, Name = "Nintendo GameCube" },
                new Platform { Id = 3, Name = "Playstaion 4" }
                );
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "The Legend of Zelda: Twilight Princess", Description = "Young hero sets out to save Hyrule and Princess Zelda", YearPublished = 2006, Price = 49.99M, PlatformId=2},
                new VideoGame { Id = 2, Title = "Dragon Age: Inquisition", Description = "Your character accidently interupts a ritual that opens up rifts from another world, causing the world to be invaded by other-world being", YearPublished = 2014, Price = 60.00M, PlatformId = 3},
                new VideoGame { Id = 3, Title = "Genshin Impact", Description = "Gatcha-Type video game with an open world filled with quests and unlockables", YearPublished = 2020, Price = 0.00M, PlatformId = 1 }
                );
        }
    }
}
