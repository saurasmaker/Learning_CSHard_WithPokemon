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
            if (textBoxEnterPokemonId.Text == "Enter Pokémon Name...")
            {
                textBoxEnterPokemonId.Text = "";
                textBoxEnterPokemonId.ForeColor = Color.Black;
            }
        }

        private void textBoxEnterPokemonId_Leave(object sender, EventArgs e)
        {
            if (textBoxEnterPokemonId.Text == "")
            {
                textBoxEnterPokemonId.Text = "Enter Pokémon Name...";
                textBoxEnterPokemonId.ForeColor = Color.Gray;
            }
        }

        private void textBoxEnterPokemonId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                OPokemon p = Pokedex.LoadPokemonFromXML(textBoxEnterPokemonId.Text);

                if (p != null)
                    textBoxShowPokemonData.Text = p.Show();
                else
                    MessageBox.Show("Pokémon not finded");
            }
        }
    }
}
