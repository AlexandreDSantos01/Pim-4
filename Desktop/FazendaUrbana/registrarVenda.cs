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
    public partial class registrarVenda : Form
    {
        public registrarVenda()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro de venda?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Venda();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void btnVoltar_Enter(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Red;
        }

        private void btnVoltar_Leave(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.White;
        }

        private void btnregistrarVenda_Enter(object sender, EventArgs e)
        {
            btnregistrarVenda.BackColor = Color.LightGreen;
        }

        private void btnregistrarVenda_Leave(object sender, EventArgs e)
        {
            btnregistrarVenda.BackColor = Color.White;
        }
    }
}
