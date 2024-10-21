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
    public partial class Fornecedor : Form
    {
        public Fornecedor()
        {
            InitializeComponent();
        }

        private void CarregarDados()
        {
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Fornecedor", conectar))
                {
                    DataTable attcheck = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(attcheck);
                    }

                    // Filtra os dados com base nos checkboxes
                    DataView filtrar = attcheck.DefaultView;

                    // Criar um filtro
                    List<string> filtros = new List<string>();

                    if (check1.Checked)
                    {
                        filtros.Add("situacao = 'Ativo'");
                    }
                    if (check2.Checked)
                    {
                        filtros.Add("situacao = 'Inativo'");
                    }

                    // Aplicar filtro apenas se houver condições
                    if (filtros.Count > 0)
                    {
                        filtrar.RowFilter = string.Join(" OR ", filtros);
                    }
                    else
                    {
                        filtrar.RowFilter = ""; // Se nenhum checkbox estiver marcado, mostrar todos os itens
                    }

                    // Atribuir o tbEstoque ao DataGridView
                    tbFornecedor.DataSource = filtrar;
                }
            }
        }

        private void Fornecedor_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdonlygreenDataSet19.tb_Fornecedor'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_FornecedorTableAdapter1.Fill(this.bdonlygreenDataSet19.tb_Fornecedor);
      
            tbFornecedor.Columns[0].Width = 50;
            tbFornecedor.Columns[1].Width = 130;
            tbFornecedor.Columns[2].Width = 150;
            tbFornecedor.Columns[3].Width = 120;
            tbFornecedor.Columns[4].Width = 90;

            check1.Checked = true;
            check2.Checked = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text))
            {
                MessageBox.Show("Por favor, insira um termo de pesquisa.");
                txtPesquisar.Focus();
                return;
            }

            string pesquisar = txtPesquisar.Text;
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {

                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tb_Fornecedor WHERE nome LIKE @pesquisar OR " +
                    "nome LIKE @pesquisar OR " +
                    "cnpj LIKE @pesquisar OR " +
                     "id LIKE @pesquisar", conectar))
                {
                    cmd.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        tbFornecedor.DataSource = dt;
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da gestão de fornecedor?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Home();
                menu.Show(this);

                this.Visible = false;
            }
        }
        private void Limpar()
        {
            txtId.Clear();
            txtCNPJ.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtRua.Clear();
            txtNrua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtCEP.Clear();
            txtProdutos.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private bool ValidarCampoFornecedor()
        {

            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo nome é obrigatório.");
                txtNome.Focus();
                return true;
            }


            if (txtCNPJ.Text == "")
            {
                MessageBox.Show("O campo CPF é obrigatório.");
                txtCNPJ.Focus();
                return true;
            }



            if (txtTelefone.Text == "")
            {
                MessageBox.Show("O campo telefone é obrigatório.");
                txtTelefone.Focus();
                return true;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("O campo email é obrigatório.");
                txtEmail.Focus();
                return true;
            }

            if (txtRua.Text == "")
            {
                MessageBox.Show("O campo rua é obrigatório.");
                txtRua.Focus();
                return true;
            }

            if (txtNrua.Text == "")
            {
                MessageBox.Show("O campo número da rua é obrigatório.");
                txtNrua.Focus();
                return true;
            }

            if (txtBairro.Text == "")
            {
                MessageBox.Show("O campo bairro é obrigatório.");
                txtBairro.Focus();
                return true;
            }

            if (txtCidade.Text == "")
            {
                MessageBox.Show("O campo cidade é obrigatório.");
                txtCidade.Focus();
                return true;
            }

            if (txtEstado.Text == "")
            {
                MessageBox.Show("O campo estado é obrigatório.");
                txtEstado.Focus();
                return true;
            }

            if (txtCEP.Text == "")
            {
                MessageBox.Show("O campo cep é obrigatório.");
                txtCEP.Focus();
                return true;
            }

            return false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoFornecedor() == false)
            {
                if (!checkAtivo.Checked)
                {
                    MessageBox.Show("Você está adicionando um novo fornecedor como inativo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var resultado = MessageBox.Show("Você tem certeza que deseja adicionar esse fornecedor?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                        using (var conectar = new SqlConnection(bdonlygreen))
                        {
                            conectar.Open();
                            string add = "INSERT INTO tb_Fornecedor (nome, cnpj, telefone, email, rua, nrua, bairro, cidade, estado, cep, produtos, situacao) " +
                                         "VALUES (@nome, @cnpj, @telefone, @email, @rua, @nrua, @bairro, @cidade, @estado, @cep, @produtos, @situacao);";

                            using (SqlCommand cmd = new SqlCommand(add, conectar))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                                cmd.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
                                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                                cmd.Parameters.AddWithValue("@rua", txtRua.Text);
                                cmd.Parameters.AddWithValue("@nrua", txtNrua.Text);
                                cmd.Parameters.AddWithValue("@bairro", txtBairro.Text);
                                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                                cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                                cmd.Parameters.AddWithValue("@cep", txtCEP.Text);
                                cmd.Parameters.AddWithValue("@produtos", txtProdutos.Text);

                                // Definindo a situação
                                string situacao = checkAtivo.Checked ? "Ativo" : "Inativo";
                                cmd.Parameters.AddWithValue("@situacao", situacao);


                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Fornecedor adicionado com sucesso.");

                                var menu = new Fornecedor();
                                menu.Show(this);
                                this.Visible = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }
        }

        private DataTable GetUserDataById(int userId)
        {
            DataTable dt = new DataTable();
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var command = new SqlCommand("SELECT * FROM tb_Fornecedor WHERE id = @id", conectar))
                {
                    command.Parameters.AddWithValue("@id", userId);
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt); // Preenche o DataTable
                    }
                }
            }
            return dt;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            // Pegar e conferir ID
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para selecionar.");
                return;
            }

            // Verifica se o ID existe no banco de dados
            bool idExists = false;
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM tb_Fornecedor WHERE id = @id", conectar))
                {
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text)); // Converte para int
                    idExists = (int)command.ExecuteScalar() > 0;
                }
            }

            if (!idExists)
            {
                MessageBox.Show("O ID informado não existe na tabela.");
                return;
            }


            // Carrega os dados do usuário usando o novo método
            DataTable dt = GetUserDataById(Convert.ToInt32(txtId.Text));

            // Verifica se o DataTable não está vazio
            if (dt.Rows.Count > 0)
            {
                // Preenche os campos do formulário com os dados do usuário
                txtNome.Text = dt.Rows[0].Field<string>("nome");
                txtCNPJ.Text = dt.Rows[0].Field<string>("cnpj").ToString();
                txtEmail.Text = dt.Rows[0].Field<string>("email").ToString();
                txtTelefone.Text = dt.Rows[0].Field<string>("telefone").ToString();
                txtRua.Text = dt.Rows[0].Field<string>("rua").ToString();
                txtNrua.Text = dt.Rows[0].Field<int>("nrua").ToString();
                txtBairro.Text = dt.Rows[0].Field<string>("bairro").ToString();
                txtCidade.Text = dt.Rows[0].Field<string>("cidade").ToString();
                txtEstado.Text = dt.Rows[0].Field<string>("estado").ToString();
                txtCEP.Text = dt.Rows[0].Field<string>("cep").ToString();
                txtProdutos.Text = dt.Rows[0].Field<string>("produtos").ToString();
                // Preenche a situação do cliente
                if (dt.Rows[0].Field<string>("situacao") == "Ativo")
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
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
            // Atualizar os dados no banco de dados
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var cmd = new SqlCommand("UPDATE tb_Fornecedor SET nome = @nome, cnpj = @cnpj, telefone = @telefone, email = @email, rua = @rua, nrua = @nrua, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, produtos = @produtos, situacao = @situacao  WHERE id = @id", conectar))
                {

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@rua", txtRua.Text);
                    cmd.Parameters.AddWithValue("@nrua", txtNrua.Text);
                    cmd.Parameters.AddWithValue("@bairro", txtBairro.Text);
                    cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@cep", txtCEP.Text);
                    cmd.Parameters.AddWithValue("@produtos", txtProdutos.Text);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                    // Definindo a situação
                    string situacao = checkAtivo.Checked ? "Ativo" : "Inativo";
                    cmd.Parameters.AddWithValue("@situacao", situacao);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados atualizados com sucesso!");

                    var menu = new Fornecedor();
                    menu.Show(this);
                    this.Visible = false;
                }
            }
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
