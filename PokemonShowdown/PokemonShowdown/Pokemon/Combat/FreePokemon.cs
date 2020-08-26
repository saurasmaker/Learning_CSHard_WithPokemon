using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonShowdown.Pokemon
{
    class FreePokemon : OPokemon
    {
        #region Attributes

        private byte genre;
        private byte nature;
        private byte[] iVs;

        public bool Shyni { get; set; }
        
        #endregion




        #region Constructors
        public FreePokemon()
        {

        }


        #endregion



        #region Getters & Setters
        public byte[] IVs
        {
            get { return iVs; }
            set
            {
                for (byte i = 0; 0 < 5; ++i)
                    if (value[i] > 255)
                    {
                        Console.WriteLine("Not valid EVs {0} in position {1}", PokeStat.StatsNames[i], i);
                        return;
                    }
                    else iVs[i] = value[i];

            }
        }

        public byte Genre
        {
            get { return genre; }
            set {
                if (value < 2) genre = value;
                else genre = 0;      
            }
        }
        public byte Nature
        {
            get { return nature; }
            set {
                if (value < 25) nature = value;
                else nature = 0;      
            }
        }




        #endregion
    }
}
