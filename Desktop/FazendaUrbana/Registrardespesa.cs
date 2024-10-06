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
    public partial class registrarDespesa : Form
    {
        public registrarDespesa()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro de despesa?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Despesa();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Enter(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Red;
        }

        private void btnVoltar_Leave(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.White;
        }

        private void btnRegistrardespesa_Enter(object sender, EventArgs e)
        {
            btnRegistrardespesa.BackColor = Color.LightGreen;
        }

        private void btnRegistrardespesa_Leave(object sender, EventArgs e)
        {
            btnRegistrardespesa.BackColor = Color.White;
        }
    }
}
