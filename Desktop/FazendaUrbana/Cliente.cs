using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FazendaUrbana
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnAddcliente_Click(object sender, EventArgs e)
        {
            var menu = new Registrarcliente();
            menu.Show(this);

            this.Visible = false;
        }
    }
}
