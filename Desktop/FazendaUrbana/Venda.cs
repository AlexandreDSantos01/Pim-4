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
    public partial class Venda : Form
    {
        public Venda()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnAdduser_Click(object sender, EventArgs e)
        {
            var menu = new registrarVenda();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnVoltar_Enter(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Red;
        }

        private void btnVoltar_Leave(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.White;
        }

        private void btnAddvenda_Enter(object sender, EventArgs e)
        {
            btnAddvenda.BackColor = Color.LightGreen;
        }

        private void btnAddvenda_Leave(object sender, EventArgs e)
        {
            btnAddvenda.BackColor = Color.White;
        }
    }
}
