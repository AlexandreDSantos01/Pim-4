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
    public partial class Producao : Form
    {
        public Producao()
        {
            InitializeComponent();
        }

        private void btnAddproducao_Click(object sender, EventArgs e)
        {
            var menu = new registrarProducao();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
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

        private void btnAddproducao_Enter(object sender, EventArgs e)
        {
            btnAddproducao.BackColor = Color.LightGreen;
        }

        private void btnAddproducao_Leave(object sender, EventArgs e)
        {
            btnAddproducao.BackColor = Color.White;
        }
    }
}
