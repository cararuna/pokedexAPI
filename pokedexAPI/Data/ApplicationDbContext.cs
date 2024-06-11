using Microsoft.EntityFrameworkCore;
using pokedexAPI.Models;

namespace pokedexAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<FavoritePokemon> Favorites { get; set; }
    }
}
