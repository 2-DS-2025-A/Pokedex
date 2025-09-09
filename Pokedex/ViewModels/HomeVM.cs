using Pokedex.Models;

namespace Pokedex.ViewModels
{
    public class HomeVM
    {
        public List<Tipo> Tipos { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}