using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonShowdown.Pokemon.Combat
{
    class PokeTeam
    {
        CapturedPokemon[] pokemon;

        public PokeTeam()
        {
            this.pokemon = new CapturedPokemon[6];
        }
    }
}
