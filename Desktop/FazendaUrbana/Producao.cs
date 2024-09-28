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
    public partial class Producao : Form
    {
        public Producao()
        {
            InitializeComponent();
        }

        private void btnAddproducao_Click(object sender, EventArgs e)
        {
            var menu = new RegistrarProducao();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
            menu.Show(this);

            this.Visible = false;
        }
    }
}
