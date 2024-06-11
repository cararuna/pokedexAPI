using Microsoft.EntityFrameworkCore;
using pokedexAPI.Data;
using pokedexAPI.Models;

namespace pokedexAPI.Repositories
{
    public interface IFavoriteRepository
    {
        Task<FavoritePokemon> InsertFavorite(FavoritePokemon favoritePokemon);
        Task<FavoritePokemon?> GetFavorite(FavoritePokemon favoritePokemon);
        Task DeleteFavorite(FavoritePokemon favoritePokemon);

        Task<List<FavoritePokemon>> GetAllFavorites();
    }

    public class FavoriteRepository : IFavoriteRepository
    {

        private readonly ApplicationDbContext _context;

        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FavoritePokemon> InsertFavorite(FavoritePokemon favoritePokemon)
        {
            await _context.Favorites.AddAsync(favoritePokemon);

            await _context.SaveChangesAsync();

            return favoritePokemon;
        }

        public Task<FavoritePokemon?> GetFavorite(FavoritePokemon favoritePokemon)
        {
            return _context.Favorites.FirstOrDefaultAsync(x => x.PokemonId==favoritePokemon.PokemonId && x.UserId==favoritePokemon.UserId);
        }

        public async Task DeleteFavorite(FavoritePokemon favoritePokemon)
        {
            _context.Favorites.Remove(favoritePokemon);

            await _context.SaveChangesAsync();
        }

        public Task<List<FavoritePokemon>> GetAllFavorites()
        {
            return _context.Favorites.ToListAsync();
        }
    }
}
