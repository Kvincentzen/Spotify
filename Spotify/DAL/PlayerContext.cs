using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify.Models;
using Microsoft.EntityFrameworkCore;

namespace Spotify.DAL
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext>option) : base(option)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        //entities
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Artists> Artists { get; set; }

    }
}
