using Microsoft.EntityFrameworkCore;
using MusicLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibraryWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Song>()
                .HasData(
                    new Song
                    {
                        Id = 1,
                        Title = "Paint it Black",
                        Artist = "The Rolling Stones",
                        Album = "The Rolling Stones Greatest Hits",
                        ReleaseDate = new DateTime(1975, 5, 10)
                    },
                    new Song
                    {
                        Id = 2,
                        Title = "Back in Black",
                        Artist = "AC/DC",
                        Album = "Back in Black",
                        ReleaseDate = new DateTime(1990, 1, 1)
                    }
                );

        }
    }
}
