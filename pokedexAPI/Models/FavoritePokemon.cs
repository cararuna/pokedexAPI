using System.ComponentModel.DataAnnotations;

namespace pokedexAPI.Models
{
    public class FavoritePokemon
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PokemonId { get; set; }
    }
}
