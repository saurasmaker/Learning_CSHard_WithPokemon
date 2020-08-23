using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PokemonShowdown.Forms
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            HideSubMenus();
        }

       

        private void btnPokedexTools_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelPokedexToolsSubmenu);
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelTeamsSubmenu);

        }

        private void OpenChildForm()
        {


        }

        #region SubmenuTools
        private void HideSubMenus()
        {
            panelPokedexToolsSubmenu.Visible = false;
            panelTeamsSubmenu.Visible = false;
        }


        private void ShowSubmenu(Panel subMenu)
        {
            if (subMenu.Visible != true)
            {
                HideSubMenus();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;

        }
        #endregion

    }
}
