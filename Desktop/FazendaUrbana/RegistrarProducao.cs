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
    public partial class registrarProducao : Form
    {
        public registrarProducao()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro da produção?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Producao();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void btnRegistrarProducao_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnregistrarProducao_Enter(object sender, EventArgs e)
        {
            btnregistrarProducao.BackColor = Color.LightGreen;
        }

        private void btnregistrarProducao_Leave(object sender, EventArgs e)
        {
            btnregistrarProducao.BackColor = Color.White;
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
