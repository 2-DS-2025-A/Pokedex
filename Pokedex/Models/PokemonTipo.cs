using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models;

[Table("PokemonTipo")]
public class PokemonTipo
{
    [Key, Column(Order = 1)]
    public uint PokemonNumero { get; set; }
    [ForeignKey("PokemonNumero")]
    public Pokemon Pokemon { get; set; }

    [Key, Column(Order = 2)]
    public uint TipoId { get; set; }
    [ForeignKey("TipoId")]
    public Tipo Tipo { get; set; }
}
