using CSI250Final_GameFilter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSI250Final_GameFilter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
    }
}