using pokedexAPI.Models;
using pokedexAPI.Repositories;

namespace pokedexAPI.Services
{
    public interface IFavoritesService
    {
        Task<int> AddFavorite(int userId, int pokemonId);

        Task RemoveFavorite(int userId, int pokemonId);

        Task<List<FavoritePokemon>> GetAllFavorites();
    }

    public class FavoritesService : IFavoritesService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoritesService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }


        public async Task<int> AddFavorite(int userId, int pokemonId)
        {
            var pokemon = await _favoriteRepository.GetFavorite(new Models.FavoritePokemon
            {
                PokemonId = pokemonId,
                UserId = userId,
            });

            if (pokemon != null)
            {
                return pokemon.Id;
            }

            var newPokemon = await _favoriteRepository.InsertFavorite(new Models.FavoritePokemon
            {
                PokemonId = pokemonId,
                UserId = userId,
            });

            return newPokemon.Id;


        }

        public async Task RemoveFavorite(int userId, int pokemonId)
        {
            var pokemon = await _favoriteRepository.GetFavorite(new Models.FavoritePokemon
            {
                PokemonId = pokemonId,
                UserId = userId,
            });

            if (pokemon != null) {
                await _favoriteRepository.DeleteFavorite(pokemon);
            }
        }

        public async Task<List<FavoritePokemon>> GetAllFavorites()
        {
            return await _favoriteRepository.GetAllFavorites();
        }
    }
}
