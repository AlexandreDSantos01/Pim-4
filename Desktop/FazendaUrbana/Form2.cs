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
    public partial class CadastroUsuario : Form
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltarUsuario_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro de usuário?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Usuario();
                menu.Show(this);

                this.Visible = false;
            }    
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetterOrDigit(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas letras ou números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnVoltarUsuario_Enter(object sender, EventArgs e)
        {
            btnVoltarUsuario.BackColor = Color.Red;
        }

        private void btnVoltarUsuario_Leave(object sender, EventArgs e)
        {
            btnVoltarUsuario.BackColor = Color.White;
        }

        private void btnCadastrar_Enter(object sender, EventArgs e)
        {
            btnCadastrar.BackColor = Color.LightGreen;
        }

        private void btnCadastrar_Leave(object sender, EventArgs e)
        {
            btnCadastrar.BackColor = Color.White;
        }
    }
}
