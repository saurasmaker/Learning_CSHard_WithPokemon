using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonShowdown.Pokemon
{
    class CapturedPokemon : FreePokemon
    {
        #region Attributes
        public byte Level { get; set; }
        public ulong Experience { get; set; }
        public byte Pokeball { get; set; }

        #endregion

        #region Constructors
        public CapturedPokemon()
        {

        }

        #endregion


        #region LevelCalculator
        public byte LevelCalculator(byte lvlType)
        {
            return lvlType switch
            {
                0 => FastLevelCalculator(),
                1 => MediumLevelCalculator(),
                2 => SlowLevelCalculator(),
                3 => ParabolicLevelCalculator(),
                4 => ErraticLevelCalculator(),
                5 => FluctuatingLevelCalculator(),
                _ => 0,
            };
        }


        private byte FastLevelCalculator() //Fórmula: E = 4 * n^3 / 5
        {
            byte n = (byte)(Level + 1);
            ulong newExp = Experience;

            if ((newExp -= (ulong)(Math.Pow(n, 3) * 4 / 5)) <= 0)
            {
                Experience = newExp;
                return n;
            }

            return Level;
        }

        private byte MediumLevelCalculator() //Fórmula: E = n^3
        {
            byte n = (byte)(Level + 1);
            ulong newExp = Experience;

            if ((newExp -= (ulong)Math.Pow(Level + 1, 3)) <= 0)
            {
                Experience = newExp;
                return n;
            }

            return Level;
        }

        private byte SlowLevelCalculator() //Fórmula: E = 5 * n^3 / 4
        {
            byte n = (byte)(Level + 1);
            ulong newExp = Experience;

            if ((newExp -= (ulong)Math.Pow(n, 3) * 5 / 4) <= 0)
            {
                Experience = newExp;
                return n;
            }

            return Level;
        }

        private byte ParabolicLevelCalculator() //Fórmula: E = 6/5*n^3 − 15*n^2 + 100*n − 140
        {
            byte n = (byte)(Level + 1);
            ulong newExp = Experience;

            if ((newExp -= (ulong)((6 / 5 * Math.Pow(n, 3)) - (15 * Math.Pow(n, 2)) + (100 * n) - 140)) <= 0)
            {
                Experience = newExp;
                return n;
            }

            return Level;
        }

        private byte ErraticLevelCalculator()
        {
            byte n = (byte)(Level + 1);
            ulong newExp = Experience;

            if (0 < n && n <= 50)
            {
                if ((newExp -= (ulong)(Math.Pow(n, 3) * (2 - (0.02 * n)))) <= 0)
                {
                    Experience = newExp;
                    return n;
                }
            }

            else if (51 <= n && n <= 68)
            {
                if ((newExp -= (ulong)(Math.Pow(n, 3) * (1.5 - (0.01 * n)))) <= 0)
                {
                    Experience = newExp;
                    return n;
                }
            }

            else if (69 <= n && n <= 98)
            {
                if ((newExp -= (ulong)(Math.Pow(n, 3) * (1.274 - (0.02 * n / 3) - (n % 3)))) <= 0)
                {
                    Experience = newExp;
                    return n;
                }
            }

            else if (99 <= n && n <= 100)
            {
                if ((newExp -= (ulong)(Math.Pow(n, 3) * (1.6 - (0.01 * n)))) <= 0)
                {
                    Experience = newExp;
                    return n;
                }
            }

            return Level;
        }

        private byte FluctuatingLevelCalculator()
        {
            byte n = (byte)(Level + 1);
            ulong newExp = Experience;

            if (0 < n && n <= 15)
            {
                if ((newExp -= (ulong)(Math.Pow(n, 3) * ((24 + ((n + 1) / 3)) / 50))) <= 0)
                {
                    Experience = newExp;
                    return n;
                }
            }

            else if (16 <= n && n <= 35)
            {
                if ((newExp -= (ulong)(Math.Pow(n, 3) * ((14 + n) / 50))) <= 0)
                {
                    Experience = newExp;
                    return n;
                }
            }

            else if (36 <= n && n <= 100)
            {
                if ((newExp -= (ulong)(Math.Pow(n, 3) * ((32 + (n / 2)) / 50))) <= 0)
                {
                    Experience = newExp;
                    return n;
                }
            }

            return Level;
        }
        #endregion
    }
}
