using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonShowdown.Pokemon
{

    class PokeStat
    {
        public static string[] StatsNames = new string[] {
            "health", "attack", "specialAttack", "defense", "specialDefense", "speed"
        };

        public static byte Health = 0;
        public static byte Attack = 1;
        public static byte SpecialAttack = 2;
        public static byte Defense = 3;
        public static byte SpecialDefense = 4;
        public static byte Speed = 5;
    }
}
