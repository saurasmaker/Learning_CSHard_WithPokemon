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
        Index index;
        public SearchPokemonByName(Index index)
        {
            this.index = index;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OPokemon p = Pokedex.LoadPokemonFromPokedexXML(textBoxSearchPoke.Text);

            if (index != null && p != null)
                index.OpenChildForm(new AddOrUpdatePokemonForm(p));

            else
                MessageBox.Show(textBoxSearchPoke.Text + "Not Finded");

            Dispose();
        }
    }
}
