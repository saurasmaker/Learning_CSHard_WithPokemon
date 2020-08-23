using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonShowdown.Pokemon
{
    class FreePokemon : OPokemon
    {
        #region Attributes
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
                        Console.WriteLine("Not valid EVs {0} in position {1}", StatNames[i], i);
                        return;
                    }
                    else iVs[i] = value[i];

            }
        }

        


        #endregion
    }
}
