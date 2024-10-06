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
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnAddproducao_Click(object sender, EventArgs e)
        {
            var menu = new registrarRelatorio();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnAddrelatorio_Enter(object sender, EventArgs e)
        {
            btnAddrelatorio.BackColor = Color.LightGreen;
        }

        private void btnAddrelatorio_Leave(object sender, EventArgs e)
        {
            btnAddrelatorio.BackColor = Color.White;
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
