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
    public partial class registrarRelatorio : Form
    {
        public registrarRelatorio()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro de relatório?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Relatorio();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void btnregistrarRelatorio_Enter(object sender, EventArgs e)
        {
            btnregistrarRelatorio.BackColor = Color.LightGreen;
        }

        private void btnregistrarRelatorio_Leave(object sender, EventArgs e)
        {
            btnregistrarRelatorio.BackColor = Color.White;
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
