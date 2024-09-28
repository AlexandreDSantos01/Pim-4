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
    public partial class Registrardespesa : Form
    {
        public Registrardespesa()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var menu = new Despesa();
            menu.Show(this);

            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
