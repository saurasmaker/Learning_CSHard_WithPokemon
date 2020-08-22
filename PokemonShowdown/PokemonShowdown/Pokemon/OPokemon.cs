using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PokemonShowdown.Pokemon
{
    class OPokemon
    {
        //Static Structs
        public struct Stat
        {
            public static int health = 0;
            public static int attack = 1;
            public static int espAttack = 2;
            public static int defense = 3;
            public static int espDefense = 4;
            public static int speed = 5;      
        }

        public struct Type
        {
            public static int normal = 0;
            public static int fighting = 1;
            public static int flying = 2;
            public static int poison = 3;
            public static int ground = 4;
            public static int rock = 5;
            public static int bug = 6;
            public static int ghost = 7;
            public static int steel = 8;
            public static int fire = 9;
            public static int water = 10;
            public static int grass = 11;
            public static int electric = 12;
            public static int psychic = 13;
            public static int ice = 14;
            public static int dragon = 15;
            public static int dark = 16;
            public static int fairy = 17;
        }

        public struct LevelType
        {
            public static int fast = 0;
            public static int medium = 1;
            public static int slow = 2;
            public static int parabolic = 3;
            public static int erratic = 4;
            public static int fluctuating = 5;
        }

        //Static Attributes     
        public static string[] StatNames = new string[] {"health", "attack", "specialAttack", "defense", "specialDefense", "speed" };
        public static string[] TypeNames = new string[] { 
            "normal", "fighting", "flying", "poison", "ground", "rock", "bug", "ghost", "steel", "fire", "water",
            "grass", "electric", "psychic", "ice", "dragon", "dark", "fairy" 
        };
        
        
        
        //Attributes
        private string description;
        private byte[] iVs;
        private byte[] eVs;

        private byte levelType;



        //Constructors
        public OPokemon()
        {
        }


        //Methods
        public string Show()
        {
            return (" Nombre: " + Name +
            "\n Tipo: " + Kind +
            "\n Descripción: " + Description +
            "\n PS: " + Health +
            "\n Ataque: " + Attack +
            "\n Ataque Esp: " + SpecialAttack +
            "\n Defense: " + Defense +
            "\n Defense Esp: " + SpecialDefense +
            "\n Velocidad: " + Speed);
        }


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






        //Getters && Setters
        public string Id { get; set; }
        public string Name { get; set; }

        public string Kind { get; set; }

        public string Description
        {
            get { return description; }
            set { if(value.Length < 1000) description = value; }
        }

        public byte Health { get; set; }

        public byte Attack { get; set; }

        public byte SpecialAttack { get; set; }

        public byte Defense { get; set; }

        public byte SpecialDefense { get; set; }

        public byte Speed { get; set; }

        public byte Level { get; set; }

        public ulong Experience { get; set; }

        public byte[] IVs
        {
            get { return iVs; }
            set {
                for (byte i = 0; 0 < 5; ++i)
                    if (value[i] > 31)
                    {
                        Console.WriteLine("Not valid IVs {0} in position {1}", StatNames[i], i);
                        return;
                    }
                    else eVs[i] = value[i];
            }
        }

        public byte[] EVs
        {
            get { return eVs; }
            set
            {
                for (byte i = 0; 0 < 5; ++i)
                    if (value[i] > 255)
                    {
                        Console.WriteLine("Not valid EVs {0} in position {1}", StatNames[i], i);
                        return;
                    }
                    else eVs[i] = value[i];

            }
        }

        public bool Shiny { get; set; }

        public byte GetLevelType()
        { return levelType; }

        public void SetLevelType(byte value)
        { if (value < 6) levelType = value; else Console.WriteLine("Not valid Level type value"); }


    }
}
