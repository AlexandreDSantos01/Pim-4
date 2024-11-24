using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlygreen
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();

            check1.Checked = true;
            check2.Checked = true;
        }

        // Método para carregar os dados no DataGridView
        private void CarregarDados()
        {
            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (SqlCommand pegardados = new SqlCommand("SELECT * FROM tb_Cliente", conectar))
                {
                    DataTable ativoinativo = new DataTable();

                    using (SqlDataAdapter resp = new SqlDataAdapter(pegardados))
                    {
                        resp.Fill(ativoinativo);
                    }

                    
                    DataView versituacao = ativoinativo.DefaultView;

                  
                    List<string> filtro = new List<string>();

                    if (check1.Checked)
                    {
                        filtro.Add("situacao = 'Ativo'");
                    }
                    if (check2.Checked)
                    {
                        filtro.Add("situacao = 'Inativo'");
                    }

         
                    if (filtro.Count > 0)
                    {
                        versituacao.RowFilter = string.Join(" OR ", filtro);
                    }
                    else
                    {
                        versituacao.RowFilter = ""; 
                    }

                    // Atribuir o tbEstoque ao DataGridView
                    tbCliente.DataSource = versituacao;
                }
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdonlygreenDataSet17.tb_Cliente'. Você pode movê-la ou removê-la conforme necessário.
            //this.tb_ClienteTableAdapter1.Fill(this.bdonlygreenDataSet17.tb_Cliente);


            tbCliente.Columns[0].Width = 50;
            tbCliente.Columns[1].Width = 100;
            tbCliente.Columns[2].Width = 120;
            tbCliente.Columns[3].Width = 120;
            tbCliente.Columns[4].Width = 100;
            
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da gestão de cliente?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Home();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text))
            {
                MessageBox.Show("Por favor, insira um termo de pesquisa.");
                return;
            }

            string pesquisar = txtPesquisar.Text;

            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";

            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {

                conectar.Open();
                using (SqlCommand buscar = new SqlCommand( "SELECT * FROM tb_Cliente WHERE nome LIKE @pesquisar OR " +
                                                        "cpf LIKE @pesquisar OR " +
                                                        "id LIKE @pesquisar", conectar))
                {
                    buscar.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");

                    DataTable vpesquisa = new DataTable();

                    using (SqlDataAdapter wpesquisa = new SqlDataAdapter(buscar))
                    {
                        wpesquisa.Fill(vpesquisa);
                        tbCliente.DataSource = vpesquisa;
                    }
                }
            }
        }

        private bool ValidarCampo()
        {

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para alterar.");
                txtId.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo nome é obrigatório.");
                txtNome.Focus();
                return true;
            }


            if (string.IsNullOrWhiteSpace(txtCPF.Text)) 
            {
                MessageBox.Show("O campo CPF é obrigatório.");
                txtCPF.Focus();
                return true;
            }

            
            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("O campo telefone é obrigatório.");
                txtTelefone.Focus();
                return true;
            }
           
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("O campo email é obrigatório.");
                txtEmail.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtRua.Text))
            {
                MessageBox.Show("O campo rua é obrigatório.");
                txtRua.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNrua.Text))
            {
                MessageBox.Show("O campo número da rua é obrigatório.");
                txtNrua.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtBairro.Text))
            {
                MessageBox.Show("O campo bairro é obrigatório.");
                txtBairro.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCidade.Text))
            {
                MessageBox.Show("O campo cidade é obrigatório.");
                txtCidade.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("O campo estado é obrigatório.");
                txtEstado.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                MessageBox.Show("O campo cep é obrigatório.");
                txtCEP.Focus();
                return true;
            }

            return false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampo())
            {
                if (!checkAtivo.Checked)
                {
                    MessageBox.Show("Você está adicionando um novo cliente como inativo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var resultado = MessageBox.Show("Você tem certeza que deseja adicionar esse cliente?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    classCliente classcliente = new classCliente();

                    classcliente.nome = txtNome.Text;
                    classcliente.cpf = txtCPF.Text;
                    classcliente.telefone = txtTelefone.Text;
                    classcliente.email = txtEmail.Text;
                    classcliente.rua = txtRua.Text;
                    classcliente.nrua = txtNrua.Text;
                    classcliente.bairro = txtBairro.Text;
                    classcliente.cidade = txtCidade.Text;
                    classcliente.estado = txtEstado.Text;
                    classcliente.cep = txtCEP.Text;

                    string situacao = checkAtivo.Checked ? "Ativo" : "Inativo";

                    classcliente.situacao = situacao;

                    classCliente.INSERTcliente(classcliente);

                    var menu = new Cliente();
                        menu.Show(this);
                        this.Visible = false;

                }
            }
        }


        private void Limpar()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtNrua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtCEP.Clear();
            checkAtivo.Checked = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja limpar todos os campos de texto?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                Limpar();
            }
        }

        private void COUNTCliente()
        {
            bool idExists = false;

            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var procurarID = new SqlCommand("SELECT COUNT(*) FROM tb_Cliente WHERE id = @id", conectar))
                {
                    procurarID.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                    idExists = (int)procurarID.ExecuteScalar() > 0;
                }
            }

            if (!idExists)
            {
                MessageBox.Show("O ID informado não existe na tabela.");
                return;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para selecionar.");
                txtId.Focus();
                return;
            }

            COUNTCliente();

            DataTable cliente = classCliente.SELECTcliente(Convert.ToInt32(txtId.Text));

           
            if (cliente.Rows.Count > 0)
            {
           
                txtNome.Text = cliente.Rows[0].Field<string>("nome");
                txtCPF.Text = cliente.Rows[0].Field<string>("cpf");
                txtEmail.Text = cliente.Rows[0].Field<string>("email").ToString();
                txtTelefone.Text = cliente.Rows[0].Field<string>("telefone").ToString();
                txtRua.Text = cliente.Rows[0].Field<string>("rua").ToString();
                txtNrua.Text = cliente.Rows[0].Field<int>("nrua").ToString();
                txtBairro.Text = cliente.Rows[0].Field<string>("bairro").ToString();
                txtCidade.Text = cliente.Rows[0].Field<string>("cidade").ToString();
                txtEstado.Text = cliente.Rows[0].Field<string>("estado").ToString();
                txtCEP.Text = cliente.Rows[0].Field<string>("cep").ToString();

                
                if (cliente.Rows[0].Field<string>("situacao") == "Ativo")
                {
                    checkAtivo.Checked = true;
                }
                else
                {
                    checkAtivo.Checked = false;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampo())
            {
                if (!checkAtivo.Checked)
                {
                    MessageBox.Show("Você está alterando um cliente como inativo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var resultado = MessageBox.Show("Você tem certeza que deseja alterar esse cliente?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    classCliente classcliente = new classCliente();

                    classcliente.nome = txtNome.Text;
                    classcliente.cpf = txtCPF.Text;
                    classcliente.telefone = txtTelefone.Text;
                    classcliente.email = txtEmail.Text;
                    classcliente.rua = txtRua.Text;
                    classcliente.nrua = txtNrua.Text;
                    classcliente.bairro = txtBairro.Text;
                    classcliente.cidade = txtCidade.Text;
                    classcliente.estado = txtEstado.Text;
                    classcliente.cep = txtCEP.Text;

                    string situacao = checkAtivo.Checked ? "Ativo" : "Inativo";

                    classcliente.situacao = situacao;

                    classCliente.UPDATEcliente(classcliente);

                    var menu = new Cliente();
                    menu.Show(this);
                    this.Visible = false;

                }
            }
        }

 //IGNORAR
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
 //IGNORAR


        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }


        //FOCO
        private void btnVoltar_Enter(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Red;
        }

        private void btnVoltar_Leave(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Silver;
        }

        private void txtPesquisar_Enter(object sender, EventArgs e)
        {
            txtPesquisar.BackColor = Color.LightBlue;

        }

        private void txtPesquisar_Leave(object sender, EventArgs e)
        {
            txtPesquisar.BackColor = Color.White;
        }

        private void btnBuscar_Enter(object sender, EventArgs e)
        {
            btnBuscar.BackColor = Color.LightGreen;
        }

        private void btnBuscar_Leave(object sender, EventArgs e)
        {
            btnBuscar.BackColor = Color.Silver;
        }

        private void btnAdicionar_Enter(object sender, EventArgs e)
        {
            btnAdicionar.BackColor = Color.LightGreen;
        }

        private void btnAdicionar_Leave(object sender, EventArgs e)
        {
            btnAdicionar.BackColor = Color.Silver;
        }

        private void btnLimpar_Enter(object sender, EventArgs e)
        {
            btnLimpar.BackColor = Color.LightGreen;
        }

        private void btnLimpar_Leave(object sender, EventArgs e)
        {
            btnLimpar.BackColor = Color.Silver;
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            txtId.BackColor = Color.LightBlue;
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            txtId.BackColor = Color.White;
        }

        private void btnSelecionar_Enter(object sender, EventArgs e)
        {
            btnSelecionar.BackColor = Color.LightGreen;
        }

        private void btnSelecionar_Leave(object sender, EventArgs e)
        {
            btnSelecionar.BackColor = Color.Silver;
        }

        private void btnSalvar_Enter(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.Orange;
        }

        private void btnSalvar_Leave(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.Silver;
        }


        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.LightBlue;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.White;
        }

        private void txtCPF_Enter(object sender, EventArgs e)
        {
            txtCPF.BackColor = Color.LightBlue;
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            txtCPF.BackColor = Color.White;
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            txtTelefone.BackColor = Color.LightBlue;
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            txtTelefone.BackColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.LightBlue;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
        }

        private void txtRua_Enter(object sender, EventArgs e)
        {
            txtRua.BackColor = Color.LightBlue;
        }

        private void txtRua_Leave(object sender, EventArgs e)
        {
            txtRua.BackColor = Color.White;
        }

        private void txtNrua_Enter(object sender, EventArgs e)
        {
            txtNrua.BackColor = Color.LightBlue;
        }

        private void txtNrua_Leave(object sender, EventArgs e)
        {
            txtNrua.BackColor = Color.White;
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.LightBlue;
        }

        private void txtBairro_Leave(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.White;
        }

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.LightBlue;
        }

        private void txtCidade_Leave(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.White;
        }

        private void txtEstado_Enter(object sender, EventArgs e)
        {
            txtEstado.BackColor = Color.LightBlue;
        }

        private void txtEstado_Leave(object sender, EventArgs e)
        {
            txtEstado.BackColor = Color.White;
        }

        private void txtCEP_Enter(object sender, EventArgs e)
        {
            txtCEP.BackColor = Color.LightBlue;
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            txtCEP.BackColor = Color.White;
        }
    }
}
