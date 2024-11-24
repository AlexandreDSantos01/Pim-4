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
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void Estoque_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdonlygreenDataSet13.tb_Estoque'. Você pode movê-la ou removê-la conforme necessário.
            //this.tb_EstoqueTableAdapter1.Fill(this.bdonlygreenDataSet13.tb_Estoque);


            tbEstoque.Columns[0].Width = 50;
            tbEstoque.Columns[1].Width = 100;
            tbEstoque.Columns[2].Width = 105;
            tbEstoque.Columns[3].Width = 150;
            tbEstoque.Columns[4].Width = 100;
            tbEstoque.Columns[5].Width = 100;

            checkDisponivel.Checked = true;
            checkEsgotado.Checked = true;
        }

        // Método para carregar os dados no DataGridView
        private void CarregarDadosEstoque()
        {
            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Estoque", conectar))
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

                    if (checkDisponivel.Checked)
                    {
                        filtros.Add("situacao = 'Disponível'");
                    }
                    if (checkEsgotado.Checked)
                    {
                        filtros.Add("situacao = 'Esgotado'");
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
                    tbEstoque.DataSource = filtrar;
                }
            }
        }



        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da gestão de estoque?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

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
                MessageBox.Show("Por favor: insira um id, nome ou preço.");
                txtPesquisar.Focus();
                return;
            }

            string pesquisar = txtPesquisar.Text;
            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {

                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tb_Estoque WHERE nome LIKE @pesquisar OR " +
                    "id LIKE @pesquisar", conectar))
                {
                    cmd.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        tbEstoque.DataSource = dt;
                    }
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdproducao.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para selecionar.");
                txtIdproducao.Focus();
                return;
            }

            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conectar;
                    cmd.CommandText = "SELECT * FROM tb_Producao WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", txtIdproducao.Text);

                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            txtIdproducao.Text = dt.Rows[0]["id"].ToString();
                            txtNome.Text = dt.Rows[0]["nome"].ToString();
                            txtEstimativa.Text = dt.Rows[0]["estimativa"].ToString();
                            txtDregistroProducao.Text = dt.Rows[0]["dregistro"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro encontrado com esse ID. \nPor favor, verificar a tabela da produção.");
                        }
                    }
                }

            }
        }

        private void btnSalvar2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtIdproducao.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para alterar.");
                txtIdproducao.Focus();
                return;
            }

            if (ValidarCampoEstoque() == false)
            {
                string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";

                using (SqlConnection conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();
                    using (SqlTransaction transaction = conectar.BeginTransaction())
                    {
                        try
                        {
                            // Insere na tabela TB_Estoque
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = conectar;
                                cmd.Transaction = transaction;

                                // Define a situação com base na quantidade
                                string situacao = Convert.ToInt32(txtQuantidade.Text) > 0 ? "Disponível" : "Esgotado";

                                cmd.CommandText = "INSERT INTO tb_Estoque (nome, quantidade, dregistroProducao, estimativaProducao, dcolheita, validade, preco, situacao) " +
                                                  "VALUES (@nome, @quantidade, @dregistroProducao, @estimativaProducao, GETDATE(), @validade, @preco, @situacao)";

                                // Corrigindo para usar o valor do TextBox     
                                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                                cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(txtQuantidade.Text));
                                cmd.Parameters.AddWithValue("@dregistroProducao", txtDregistroProducao.Text);
                                cmd.Parameters.AddWithValue("@estimativaProducao", txtEstimativa.Text);

                                // Validação da data de validade
                                DateTime validade;
                                if (!DateTime.TryParse(txtValidade.Text, out validade) || validade < DateTime.Today)
                                {
                                    MessageBox.Show("A data de validade é inválida ou está no passado.");
                                    return;
                                }
                                cmd.Parameters.AddWithValue("@validade", validade); // Adiciona a validade válida          
                                cmd.Parameters.AddWithValue("@preco", Convert.ToDouble(txtPreco.Text));
                                cmd.Parameters.AddWithValue("@situacao", situacao); // Adiciona o parâmetro da situação

                                cmd.ExecuteNonQuery();
                            }

                            // Deleta da tabela TB_Producao
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = conectar;
                                cmd.Transaction = transaction;
                                cmd.CommandText = "DELETE FROM tb_Producao WHERE id = @id";
                                cmd.Parameters.AddWithValue("@id", txtIdproducao.Text);

                                cmd.ExecuteNonQuery();
                            }

                            // Confirma a transação
                            transaction.Commit();
                            MessageBox.Show("Produto registrado com sucesso e removido da produção!");

                            var menu = new Estoque();
                            menu.Show(this);
                            this.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // Reverte a transação em caso de erro
                            transaction.Rollback();
                            MessageBox.Show("Erro ao registrar o produto: " + ex.Message);
                        }
                    }
                }
            }
        }




        private DataTable GetId(int userId)
        {
            DataTable dt = new DataTable();
            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var command = new SqlCommand("SELECT * FROM tb_Estoque WHERE id = @id", conectar))
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
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para selecionar.");
                txtId.Focus();
                return;
            }

            // Verifica se o ID existe no banco de dados
            bool idExists = false;
            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM tb_Estoque WHERE id = @id", conectar))
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
            DataTable dt = GetId(Convert.ToInt32(txtId.Text));

            // Verifica se o DataTable não está vazio
            if (dt.Rows.Count > 0)
            {
                txtNome.Text = dt.Rows[0].Field<string>("nome");
                txtQuantidade.Text = dt.Rows[0].Field<int>("quantidade").ToString();

                DateTime dregistroProducao = dt.Rows[0].Field<DateTime>("dregistroProducao");
                txtDregistroProducao.Text = dregistroProducao.ToString("dd/MM/yyyy");

                DateTime estimativa = dt.Rows[0].Field<DateTime>("estimativaProducao");
                txtEstimativa.Text = estimativa.ToString("dd/MM/yyyy");

                DateTime validade = dt.Rows[0].Field<DateTime>("validade");
                txtValidade.Text = estimativa.ToString("dd/MM/yyyy");
                txtPreco.Text = dt.Rows[0].Field<decimal>("preco").ToString();
            }

        }
        private bool ValidarCampoEstoque()
        {

            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo nome é obrigatório.");
                txtNome.Focus();
                return true;
            }


            if (txtQuantidade.Text == "")
            {
                MessageBox.Show("O campo quantidade é obrigatório.");
                txtQuantidade.Focus();
                return true;
            }



            if (txtDregistroProducao.Text == "")
            {
                MessageBox.Show("O campo registro da produção é obrigatório.");
                txtDregistroProducao.Focus();
                return true;
            }

            if (txtEstimativa.Text == "")
            {
                MessageBox.Show("O campo estimativa da colheita é obrigatório.");
                txtEstimativa.Focus();
                return true;
            }

            if (txtPreco.Text == "")
            {
                MessageBox.Show("O campo preço é obrigatório.");
                txtPreco.Focus();
                return true;
            }
          
            if (txtValidade.Text == "")
            {
                MessageBox.Show("O campo validade é obrigatório.");
                txtValidade.Focus();
                return true;
            }

            return false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para alterar.");
                txtId.Focus();
                return;
            }

            if (ValidarCampoEstoque() == false)
            { 
            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
                using (var conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();
                    using (var cmd = new SqlCommand("UPDATE tb_Estoque SET quantidade = @quantidade, dregistroProducao = @dregistroProducao, estimativaProducao = @estimativaProducao, validade = @validade, valornutritivo = @valornutritivo, preco = @preco, situacao = @situacao WHERE id = @id", conectar))
                    {
                        cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(txtQuantidade.Text));
                        cmd.Parameters.AddWithValue("@preco", Convert.ToDouble(txtPreco.Text));
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                        // Define a situação com base na quantidade
                        string situacao = Convert.ToInt32(txtQuantidade.Text) > 0 ? "Disponível" : "Esgotado";
                        cmd.Parameters.AddWithValue("@situacao", situacao);

                        DateTime validade;

                        if (!DateTime.TryParse(txtValidade.Text, out validade) || validade < DateTime.Today)
                        {
                            MessageBox.Show("A data de validade é inválida ou está no passado.");
                            return;
                        }

                        // Adiciona as datas válidas aos parâmetros
                        cmd.Parameters.AddWithValue("@dregistroProducao", txtDregistroProducao.Text);
                        cmd.Parameters.AddWithValue("@estimativaProducao", txtEstimativa.Text);
                        cmd.Parameters.AddWithValue("@validade", validade);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Dados atualizados com sucesso!");

                        var menu = new Estoque();
                        menu.Show(this);
                        this.Visible = false;
                    }
                }
            }
        }

        private void Limpar()
        {
            txtId.Clear();
            txtIdproducao.Clear();
            txtNome.Clear();
            txtQuantidade.Clear();
            txtValidade.Clear();
            txtPreco.Clear();
            txtDregistroProducao.Clear(); 
            txtEstimativa.Clear();  
        }   
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja limpar todos os campos de texto?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                Limpar();
            }
        }

        private void checkDisponivel_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDadosEstoque();
        }

        private void checkEsgotado_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDadosEstoque();
        }


        //FOCO
        
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

        private void txtIdproducao_Enter(object sender, EventArgs e)
        {
            txtIdproducao.BackColor = Color.LightBlue;
        }

        private void txtIdproducao_Leave(object sender, EventArgs e)
        {
            txtIdproducao.BackColor = Color.White;
        }

        private void btnAdicionar_Enter(object sender, EventArgs e)
        {
            btnAdicionar.BackColor = Color.LightGreen;
        }

        private void btnAdicionar_Leave(object sender, EventArgs e)
        {
            btnAdicionar.BackColor = Color.Silver;
        }

        private void btnSalvar2_Enter(object sender, EventArgs e)
        {
            btnSalvar2.BackColor = Color.LightGreen;
        }

        private void btnSalvar2_Leave(object sender, EventArgs e)
        {
            btnSalvar2.BackColor = Color.Silver;
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

        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            txtQuantidade.BackColor = Color.LightBlue;
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            txtQuantidade.BackColor = Color.White;
        }

        private void txtPreco_Enter(object sender, EventArgs e)
        {
            txtPreco.BackColor = Color.LightBlue;
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            txtPreco.BackColor = Color.White;
        }


        private void txtValidade_Enter(object sender, EventArgs e)
        {
            txtValidade.BackColor = Color.LightBlue;
        }

        private void txtValidade_Leave(object sender, EventArgs e)
        {
            txtValidade.BackColor = Color.White;
        }

        private void btnVoltar_Enter(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Red;
        }

        private void btnVoltar_Leave(object sender, EventArgs e)
        {
            btnVoltar.BackColor = Color.Silver;
        }

    }
}
