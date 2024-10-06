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
    public partial class Fornecedor : Form
    {
        public Fornecedor()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnAddfornecedor_Click(object sender, EventArgs e)
        {
            var menu = new registrarFornecedor();
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

        private void btnAddfornecedor_Enter(object sender, EventArgs e)
        {
            btnAddfornecedor.BackColor = Color.LightGreen;
        }

        private void btnAddfornecedor_Leave(object sender, EventArgs e)
        {
            btnAddfornecedor.BackColor = Color.White;
        }
    }
}
