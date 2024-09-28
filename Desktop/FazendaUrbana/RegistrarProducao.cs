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
    public partial class RegistrarProducao : Form
    {
        public RegistrarProducao()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new Producao();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnRegistrarProducao_Click(object sender, EventArgs e)
        {

        }
    }
}
