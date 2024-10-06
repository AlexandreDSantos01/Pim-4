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
            var menu = new registrarCliente();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnAddcliente_Enter(object sender, EventArgs e)
        {
            btnAddcliente.BackColor = Color.LightGreen;
        }

        private void btnAddcliente_Leave(object sender, EventArgs e)
        {
            btnAddcliente.BackColor = Color.White;
        }

        private void btnVoltar_Enter(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Red;
        }

        private void btnVoltar_Leave(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.White;
        }
    }
}
