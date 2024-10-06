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
    public partial class registrarCliente : Form
    {
        public registrarCliente()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da área de registro de cliente?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Cliente();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void btnRegistrarcliente_Enter(object sender, EventArgs e)
        {
            btnRegistrarcliente.BackColor = Color.LightGreen;
        }

        private void btnRegistrarcliente_Leave(object sender, EventArgs e)
        {
            btnRegistrarcliente.BackColor = Color.White;
        }

        private void btnRegistrarcliente_Click(object sender, EventArgs e)
        {
            
        }
    }
}
