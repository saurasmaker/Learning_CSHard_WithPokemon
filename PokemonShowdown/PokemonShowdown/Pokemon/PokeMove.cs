using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace PokemonShowdown.Pokemon
{

    class PokeMove
    {
        #region Static Attributes
        public static string[]  TypeMoveNames = new string[] {
            "Physical", "Special", "State"
        };

        public static byte Physical = 0; 
        public static byte Special = 1; 
        public static byte State = 2;

        #endregion

        #region Attributes
        private byte type; //
        private byte category; //
        private byte accuarcy; //
        private sbyte damage; //damage done by movement

        private sbyte[] modifierStats; //It indicates the affected statistic of the pokémon that has used the movement and how much it goes up or down. Depends on sign of the attribute.
        private sbyte[] modifierEnemyStats; //It indicates the affected statistic of the pokémon that receives movement and how much it goes up or down.       
       
        private byte probabilityModifierStats; //probability of making a state change when using the move. Measured in percentage
        private byte probabilityModifierEnemyStats; //probability of making a state change when using the move. Measured in percentage    
        private byte probabilityModifierEnemyStatus; //probability of making a status change when using the move. Measured in percentage
        private byte probabilityModifierVolatileStatus; //probability of making a volatile status change when using the move. Measured in percentage
        private byte probabilityModifierEnemyVolatileStatus; //probability of making a volatile status change when using the move. Measured in percentage


        public string Name { get; set; }
        public string Description { get; set; }
        public byte Repeat { get; set; } //How many times the movement is repeated after the first use
        public sbyte Recover { get; set; } //percentage of life gained based on damage done. If this attribute is negative, instead of recover will be a recoil of health.
        public bool[] ModifierEnemyStatus { get; set; }//It indicates the affected status of the pokémon that receives movement and how much it goes up or down.
        public bool[] ModifierVolatileStatus { get; set; }//It indicates the affected volatile status of the pokémon that receives movement and how much it goes up or down.
        public bool[] ModifierEnemyVolatileStatus { get; set; }//It indicates the affected volatile status of the pokémon that receives movement and how much it goes up or down.



        #endregion

        #region Constructors
        public PokeMove()
        {

        }

        #endregion


        #region Methods
        #endregion

        #region Getters & Setters
        public byte Type
        {
            get
            { return type; }
            set
            {
                if (value < 18)
                    type = value;
                else type = 0;
            }
        }

        public byte Category
        { 
            get
            { return category; }
            set
            {
                if (value < 3)
                    category = value;
                else category = 0;
            }
        }

        public byte Accuarcy
        {
            get { return accuarcy; }
            set
            {
                if (value > 100 || value < 0)
                    accuarcy = 100;
                else accuarcy = value;
            }
        }

        public sbyte Damage { 
            get{ return damage; }
            set
            {
                if (value < -1)
                    damage = value;
                else damage = 0;
            }
        }
        
        
        public sbyte[] ModifierStatistics
        { 
            get{ return modifierStats; }
            set
            {
                for (int i = 0; i < 8; ++i)
                    if (value[i] >= 8)
                    {
                        modifierStats = new sbyte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        return;
                    }
                    else modifierStats = value;
            }
        }

        public byte ProbabilityModifierStats
        {
            get { return probabilityModifierStats; }
            set
            {
                if (probabilityModifierStats > 100)
                    probabilityModifierStats = 0;
                else probabilityModifierStats = value;
            }
        }


        public sbyte[] ModifierEnemyStats
        {
            get { return modifierEnemyStats; }
            set
            {
                for (int i = 0; i < 8; ++i)
                    if (value[i] >= 8)
                    {
                        modifierEnemyStats = new sbyte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        return;
                    }
                    else modifierEnemyStats = value;
            }
        }

        public byte ProbabilityModifierEnemyStats
        {
            get { return probabilityModifierEnemyStats; }
            set
            {
                if (probabilityModifierEnemyStats > 100)
                    probabilityModifierEnemyStats = 0;
                else probabilityModifierEnemyStats = value;
            }
        }

        public byte ProbabilityModifierEnemyStatus
        {
            get { return probabilityModifierEnemyStatus; }
            set
            {
                if (probabilityModifierEnemyStatus > 100)
                    probabilityModifierEnemyStatus = 0;
                else probabilityModifierEnemyStatus = value;
            }
        }

        public byte ProbabilityModifierVolatileStatus
        {
            get { return probabilityModifierVolatileStatus; }
            set
            {
                if (probabilityModifierVolatileStatus > 100)
                    probabilityModifierVolatileStatus = 0;
                else probabilityModifierVolatileStatus = value;
            }
        }

        public byte ProbabilityModifierEnemyVolatileStatus
        {
            get { return probabilityModifierEnemyVolatileStatus; }
            set
            {
                if (probabilityModifierEnemyVolatileStatus > 100)
                    probabilityModifierEnemyVolatileStatus = 0;
                else probabilityModifierEnemyVolatileStatus = value;
            }
        }



        #endregion


    }
}
