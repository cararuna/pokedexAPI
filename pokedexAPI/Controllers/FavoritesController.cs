using Microsoft.AspNetCore.Mvc;
using pokedexAPI.Domain;
using pokedexAPI.Models;
using pokedexAPI.Services;

namespace pokedexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritesController : ControllerBase
    {
        
        private readonly ILogger<FavoritesController> _logger;
        private readonly IFavoritesService _favoritesService;

        public FavoritesController(ILogger<FavoritesController> logger, IFavoritesService favoritesService)
        {
            _logger = logger;
            _favoritesService = favoritesService;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] AddFavoriteViewModel viewModel)
        {
            var newPokemonId = await _favoritesService.AddFavorite(viewModel.UserId, viewModel.PokemonId);

            _logger.LogInformation($"added new pokemon to favorites. Id: {newPokemonId}");

            return newPokemonId;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] AddFavoriteViewModel viewModel)
        {
            await _favoritesService.RemoveFavorite(viewModel.UserId, viewModel.PokemonId);

            _logger.LogInformation("Favorite removed");

            return Ok();
        }

        [HttpGet]
        public async Task<List<FavoritePokemon>> Get()
        {
            return await _favoritesService.GetAllFavorites();
        }


    }
}
