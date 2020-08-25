using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows.Forms;
using PokemonShowdown.Pokemon;

namespace PokemonShowdown.Forms.PokedexTools
{
    public partial class AddPokemonForm : Form
    {
        public AddPokemonForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }


        #region Methods
        private void InitializeComboBoxes()
        {
            for (int i = 0; i < PokeAbility.AbilitiesNames.Length; i++) {             
                comboBoxAbility1.Items.Add(PokeAbility.AbilitiesNames[i]);
                comboBoxAbility2.Items.Add(PokeAbility.AbilitiesNames[i]);
                comboBoxAbilityHidden.Items.Add(PokeAbility.AbilitiesNames[i]);
            }
            comboBoxAbility1.SelectedIndex = 0;
            comboBoxAbility2.SelectedIndex = 0;
            comboBoxAbilityHidden.SelectedIndex = 0;

            for (int i = 0; i < PokeType.TypesNames.Length; i++)
            {
                comboBoxType1.Items.Add(PokeType.TypesNames[i]);
                comboBoxType2.Items.Add(PokeType.TypesNames[i]);
            }
            comboBoxType1.SelectedIndex = 0;
            comboBoxType2.SelectedIndex = 0;

            for (int i = 0; i < PokeLevelType.LevelTypesNames.Length; i++)
            {
                comboBoxLevelType.Items.Add(PokeLevelType.LevelTypesNames[i]);
            }
            comboBoxLevelType.SelectedIndex = 0;

            return;
        }

        private void AddPokemon()
        {
            OPokemon pokemon = new OPokemon();

            if (CheckData())
            {
                /*try
                {*/
                    pokemon.Name = textBoxName.Text;
                    pokemon.Category = textBoxCategory.Text;
                    pokemon.Description = richTextBoxDescription.Text;
                    pokemon.Weight = Convert.ToUInt16(numericUpDownWeight.Value);
                    pokemon.Height = Convert.ToUInt16(numericUpDownHeight.Value);
                    //pokemon.PictureName = pictureBoxPoke.Name;

                    pokemon.Genres[0] = Convert.ToByte(numericUpDownMale.Value);
                    pokemon.Genres[1] = Convert.ToByte(numericUpDownFemale.Value);

                    pokemon.Health = Convert.ToByte(numericUpDownHP.Value);
                    pokemon.Attack = Convert.ToByte(numericUpDownAttack.Value);
                    pokemon.SpecialAttack = Convert.ToByte(numericUpDownSpecialAttack.Value);
                    pokemon.Defense = Convert.ToByte(numericUpDownDefense.Value);
                    pokemon.SpecialDefense = Convert.ToByte(numericUpDownSpecialDefense.Value);
                    pokemon.Speed = Convert.ToByte(numericUpDownSpeed.Value);

                    pokemon.GivedEVs[PokeStat.Health] = Convert.ToByte(numericUpDownHealthEVs.Value);
                    pokemon.GivedEVs[PokeStat.Attack] = Convert.ToByte(numericUpDownAttackEVs.Value);
                    pokemon.GivedEVs[PokeStat.Defense] = Convert.ToByte(numericUpDownDefenseEVs.Value);
                    pokemon.GivedEVs[PokeStat.SpecialAttack] = Convert.ToByte(numericUpDownSpecialAttackEVs.Value);
                    pokemon.GivedEVs[PokeStat.SpecialDefense] = Convert.ToByte(numericUpDownSpecialDefenseEVs.Value);
                    pokemon.GivedEVs[PokeStat.Speed] = Convert.ToByte(numericUpDownSpeedEVs.Value);

                    pokemon.Types[0] = Convert.ToSByte(comboBoxType1.SelectedIndex);
                    pokemon.Types[1] = Convert.ToSByte(comboBoxType2.SelectedIndex);

                    pokemon.Abilities[0] = Convert.ToByte(comboBoxAbility1.SelectedIndex);
                    pokemon.Abilities[1] = Convert.ToByte(comboBoxAbility2.SelectedIndex);
                    pokemon.Abilities[2] = Convert.ToByte(comboBoxAbilityHidden.SelectedIndex);

                    pokemon.LevelType = Convert.ToByte(comboBoxLevelType.SelectedIndex);

                    richTextBoxDescription.Text = pokemon.Show();

                    Pokedex.SavePokemonInPokedexXML(pokemon);

                    /*MessageBox.Show("Congratulations. You added a Pokémon succesfuly.", "Pokémon Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }catch(Exception e)
                {
                    MessageBox.Show("There was a problem added the Pokémon. Please, check the Log for more information.", "Add Pokémon Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }*/

            }

            return;
        }

        private bool CheckData()
        {
            if (textBoxName.Text == null || textBoxName.Text == "") {
                MessageBox.Show("You can not create a Pokémon without Name.", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (textBoxCategory.Text == null || textBoxCategory.Text == "")
            {
                MessageBox.Show("You can not create a Pokémon without Category.", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (richTextBoxDescription.Text == null || richTextBoxDescription.Text == "")
            {
                MessageBox.Show("You can not create a Pokémon without Description.", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (comboBoxType1.Text == null || comboBoxType1.Text == "" || comboBoxType1.SelectedIndex == 0)
            {
                MessageBox.Show("You can not create a Pokémon without a Type.", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxAbility1.Text == null || comboBoxType1.Text == "" || comboBoxAbility1.SelectedIndex == 0)
            {
                MessageBox.Show("You can not create a Pokémon without an Ability.", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }


        #endregion

        #region PictureBox Events
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
        #endregion



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that you want to close this form? All changes realized will desapear.", "Close advise", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Dispose(); 
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            AddPokemon();
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name...")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = Color.Black;
            }
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Name...";
                textBoxName.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxCategory_Enter(object sender, EventArgs e)
        {
            if (textBoxCategory.Text == "Category...")
            {
                textBoxCategory.Text = "";
                textBoxCategory.ForeColor = Color.Black;
            }
        }

        private void textBoxCategory_Leave(object sender, EventArgs e)
        {
            if (textBoxCategory.Text == "")
            {
                textBoxCategory.Text = "Category...";
                textBoxCategory.ForeColor = Color.DarkGray;
            }
        }

        private void richTextBoxDescription_Enter(object sender, EventArgs e)
        {
            if (richTextBoxDescription.Text == "Description...")
            {
                richTextBoxDescription.Text = "";
                richTextBoxDescription.ForeColor = Color.Black;
            }
        }

        private void richTextBoxDescription_Leave(object sender, EventArgs e)
        {
            if (richTextBoxDescription.Text == "")
            {
                richTextBoxDescription.Text = "Description...";
                richTextBoxDescription.ForeColor = Color.DarkGray;
            }
        }
    }
}
