using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PokemonShowdown.Forms.PokedexTools
{
    public partial class AddPokemonForm : Form
    {
        public AddPokemonForm()
        {
            InitializeComponent();
        }

        private void pictureBoxPoke_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            pictureBoxPoke.BackColor = Color.Gainsboro;
        }

        private void pictureBoxPoke_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            pictureBoxPoke.BackColor = Color.LightGray;
        }

        private void pictureBoxPoke_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdImagePoke = new OpenFileDialog(); ofdImagePoke.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
            //Aquí incluiremos los filtros que queramos.
            ofdImagePoke.FileName = "";
            ofdImagePoke.Title = "Titulo del Dialogo";
            ofdImagePoke.InitialDirectory = "C:\\";

            if (ofdImagePoke.ShowDialog() == DialogResult.OK)
            {
                /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                String path = ofdImagePoke.FileName;
                this.pictureBoxPoke.ImageLocation = path;

                //Pueden usar tambien esta forma para cargar la Imagen solo activenla y comenten la linea donde se cargaba anteriormente 
                //this.pictureBox1.ImageLocation = textBox1.Text;
                pictureBoxPoke.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
       
    }
}
