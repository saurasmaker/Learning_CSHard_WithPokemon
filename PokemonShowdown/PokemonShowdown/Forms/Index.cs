using PokemonShowdown.Pokemon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonShowdown
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void btnShowPokemon_Click(object sender, EventArgs e)
        {
       
            OPokemon p = Pokedex.LoadPokemonFromXML(textBoxEnterPokemonId.Text);
                
            if(p!=null)
                textBoxShowPokemonData.Text = p.Show();
            else
                MessageBox.Show("Pokémon not finded");

        }

        private void textBoxEnterPokemonId_Enter(object sender, EventArgs e)
        {
            if (textBoxEnterPokemonId.Text == "Enter Pokémon Id...")
            {
                textBoxEnterPokemonId.Text = "";
                textBoxEnterPokemonId.ForeColor = Color.Black;
            }
        }

        private void textBoxEnterPokemonId_Leave(object sender, EventArgs e)
        {
            if (textBoxEnterPokemonId.Text == "")
            {
                textBoxEnterPokemonId.Text = "Enter Pokémon Id...";
                textBoxEnterPokemonId.ForeColor = Color.Gray;
            }
        }
    }
}
