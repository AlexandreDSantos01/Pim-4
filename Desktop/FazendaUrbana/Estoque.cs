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
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnAdddespesa_Click(object sender, EventArgs e)
        {
            var menu = new registrarEstoque();
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

        private void btnAddestoque_Enter(object sender, EventArgs e)
        {
            btnAddestoque.BackColor = Color.LightGreen;
        }

        private void btnAddestoque_Leave(object sender, EventArgs e)
        {
            btnAddestoque.BackColor = Color.White;
        }
    }
}
