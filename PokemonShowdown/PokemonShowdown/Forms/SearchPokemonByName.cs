using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PokemonShowdown.Forms.PokedexTools;
using PokemonShowdown.Pokemon;

namespace PokemonShowdown.Forms
{
    public partial class SearchPokemonByName : Form
    {
        public static string[] Mode = new string[] { "none", "Update", "Remove" };

        public static byte Update = 1;
        public static byte Remove = 2;

        private byte mode;
        private Index index;

        public SearchPokemonByName(Index index, byte mode)
        {          
            InitializeComponent();
            this.index = index;
            this.mode = mode;

            if (mode == Update)
            {
                label1.Text += "Update";
                this.Text = "Update";
            }
            else if (mode == Remove)
            {
                label1.Text += "Remove";
                this.Text = "Remove";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OPokemon p = Pokedex.LoadPokemonFromPokedexXML(textBoxSearchPoke.Text);

            if (index != null && p != null)
                if (mode == Update)
                    index.OpenChildForm(new AddOrUpdatePokemonForm(p));
                else if (mode == Remove)
                    try { Pokedex.RemovePokemonFromPokedexXML(p.Name); }
                    catch (Exception){ MessageBox.Show("There was an error removing " + p.Name + ". Check the Log for more information.", "Error at Remove"); }
                else
                    MessageBox.Show(textBoxSearchPoke.Text + "Not Finded");

            Dispose();
        }
    }
}
