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
    public partial class registrarEstoque : Form
    {
        public registrarEstoque()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro de produto?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Estoque();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void registrarEstoque_Load(object sender, EventArgs e)
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

        private void btnregistrarEstoque_Enter(object sender, EventArgs e)
        {
            btnregistrarEstoque.BackColor = Color.LightGreen;
        }

        private void btnregistrarEstoque_Leave(object sender, EventArgs e)
        {
            btnregistrarEstoque.BackColor = Color.White;
        }
    }
}
