﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;

namespace PokemonShowdown.Pokemon
{
    class OPokemon
    {

        #region Attributes
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ushort Height { get; set; }
        public ushort Weight { get; set; }
        public string PictureName { get; set; }

        public byte Health { get; set; }
        public byte Attack { get; set; }
        public byte SpecialAttack { get; set; }
        public byte Defense { get; set; }
        public byte SpecialDefense { get; set; }
        public byte Speed { get; set; }

        private string description;
        private sbyte[] types;
        private byte[] abilities;
        private byte[] givedEVs;
        private byte[] genres;
        private byte levelType;



        #endregion

        #region Constructors
        public OPokemon()
        {
            Types = new sbyte[2] { 0, 0 };
            GivedEVs = new byte[6] { 0, 0, 0, 0, 0, 0 };
            Genres = new byte[2] { 0, 0 };
            Abilities = new byte[3] { 0, 0, 0 };
        }
        #endregion

        #region Methods
        public string Show()
        {
            return (
            "\n ||----- " + Name + " -----||" +
            "\n Category: " + Category +
            "\n Description: " + Description +
            "\n Height: " + Height +
            "\n Weight: " + Weight +
            "\n Types: " + PokeType.TypesNames[Types[0]] + " / " + PokeType.TypesNames[Types[1]] +

            "\n\n ---Abilities--- " +
            "\n  -Ability 1: " + PokeAbility.AbilitiesNames[Abilities[0]] + 
            "\n  -Ability 2: " + PokeAbility.AbilitiesNames[Abilities[1]] + 
            "\n  -Hidden: " + PokeAbility.AbilitiesNames[Abilities[1]] + 

            "\n\n ---Base Stats--- " +
            "\n Health: " + Health +
            "\n Attack: " + Attack +
            "\n Special Attack: " + SpecialAttack +
            "\n Defense: " + Defense +
            "\n Special Defense: " + SpecialDefense +
            "\n Speed: " + Speed + 

            "\n\n ---Genres Probability---" +
            "\n  -Male: " + Genres[0] +
            "\n  -Female: " + Genres[1] +

            "\n\n ---EVs it Gives--- " +
            "\n Health: " + GivedEVs[PokeStat.Health] +
            "\n Attack: " + GivedEVs[PokeStat.Attack] +
            "\n Special Attack: " + GivedEVs[PokeStat.SpecialAttack] +
            "\n Defense: " + GivedEVs[PokeStat.Defense] +
            "\n Special Defense: " + GivedEVs[PokeStat.SpecialDefense] +
            "\n Speed: " + GivedEVs[PokeStat.Speed] + 

            "\n\n Level Type: " + PokeLevelType.LevelTypesNames[LevelType] + "\n"         
            );
        }



        #endregion

        #region Static Methods
        public static OPokemon Zero()
        {

            return null;
        }
        #endregion

        #region Getters && Setters

        public string Description
        {
            get { return description; }
            set { if(value.Length < 1000) description = value; }
        }

        public sbyte[] Types
        {
            get
            {
                return types;
            }
            set
            {
                if (value[0] < 0 || value[0] > 17)
                    Debug.WriteLine("Type 1 Invalid.");

                if (value[1] < 0 || value[1] > 17)
                    Debug.WriteLine("Type 2 Invalid.");

                else
                    types = value;
            }
        }

        public byte[] Abilities
        {
            get
            {
                return abilities;
            }
            set
            {
                abilities = value;
            }
        }

        public byte[] GivedEVs
        {
            get { return givedEVs; }
            set
            {
                givedEVs = new byte[6] { 0, 0, 0, 0, 0, 0 };

                for (byte i = 0; i < 6; ++i)
                    if (value[i] > 255)
                    {
                        Console.WriteLine("Not valid EVs {0} in position {1}", PokeStat.StatsNames[i], i);
                        return;
                    }
                    else { 
                        givedEVs[i] = value[i]; 
                    }

            }
        }

        public byte[] Genres
        {
            get
            {
                return genres;
            }
            set
            {
                genres = value;
            }
        }

        public byte LevelType { 
            get 
            { 
                return levelType; 
            }
            set
            { 
                if (value < 6) levelType = value; 
                else Console.WriteLine("Not valid Level type value"); 
            }
        }

        
        
        
        #endregion

    }
}
