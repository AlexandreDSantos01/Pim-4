using System;
using System.Drawing;
using System.Windows.Forms;

namespace FazendaUrbana
{
    public partial class registrarFornecedor : Form
    {
        public registrarFornecedor()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro do fornecedor?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(resultado == DialogResult.OK)
            {
                var menu = new Fornecedor();
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

        private void btnregistrarFornecedor_Enter(object sender, EventArgs e)
        {
            btnRegistrarfornecedor.BackColor = Color.LightGreen;
        }

        private void btnregistrarFornecedor_Leave(object sender, EventArgs e)
        {
            btnRegistrarfornecedor.BackColor = Color.White;
        }
    }
}
