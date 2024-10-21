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
    public partial class Despesa : Form
    {
        public Despesa()
        {
            InitializeComponent();
        }

        private void Despesa_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdonlygreenDataSet20.tb_Despesa'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_DespesaTableAdapter1.Fill(this.bdonlygreenDataSet20.tb_Despesa);
            
            tbDespesa.Columns[0].Width = 50;
            tbDespesa.Columns[1].Width = 100;
            tbDespesa.Columns[2].Width = 115;
            tbDespesa.Columns[3].Width = 115;
            tbDespesa.Columns[4].Width = 115;
            tbDespesa.Columns[5].Width = 100;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da gestão de despesa?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

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
                txtPesquisar.Focus();
                return;
            }

            string pesquisar = txtPesquisar.Text;
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {

                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tb_Despesa WHERE nome LIKE @pesquisar OR " +
                    "nome LIKE @pesquisar OR " +
                    "id LIKE @pesquisar", conectar))
                {
                    cmd.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        tbDespesa.DataSource = dt;
                    }
                }
            }
        }

        private void Limpar()
        {
            txtId.Clear();
            txtIdfornecedor.Clear();
            txtQuantidade.Clear();
            txtValor.Clear();
            txtProduto.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private DataTable GetId(int userId)
        {
            DataTable dt = new DataTable();
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var command = new SqlCommand("SELECT * FROM tb_Despesa WHERE id = @id", conectar))
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
                using (var command = new SqlCommand("SELECT COUNT(*) FROM tb_Despesa WHERE id = @id", conectar))
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
                // Preenche os campos do formulário com os dados do usuário
                txtIdfornecedor.Text = dt.Rows[0].Field<Int32>("pk_idFornecedor").ToString();
                txtProduto.Text = dt.Rows[0].Field<string>("produto");
                txtQuantidade.Text = dt.Rows[0].Field<int>("quantidade").ToString();
                txtValor.Text = dt.Rows[0]["valor"].ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();

                // Verificando se o idFornecedor existe
                string verificar = "SELECT COUNT(*) FROM tb_Fornecedor WHERE id = @idFornecedor;";
                using (var checkFornecedorCmd = new SqlCommand(verificar, conectar))
                {
                    checkFornecedorCmd.Parameters.AddWithValue("@idFornecedor", Convert.ToInt32(txtIdfornecedor.Text)); 
                    int confere = (int)checkFornecedorCmd.ExecuteScalar();

                    if (confere == 0)
                    {
                        MessageBox.Show("Fornecedor não encontrado. Verifique o ID do fornecedor.");
                        return;
                    }
                } 

                // Atualizar os dados no banco de dados
                using (var cmd = new SqlCommand("UPDATE tb_Despesa SET quantidade = @quantidade, produto = @produto, valor = @valor, pk_idFornecedor = @idFornecedor WHERE id = @id", conectar))
                {
                    
                    cmd.Parameters.AddWithValue("@produto", txtProduto.Text);
                    cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(txtQuantidade.Text));
                    cmd.Parameters.AddWithValue("@valor", Convert.ToDecimal(txtValor.Text));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                    cmd.Parameters.AddWithValue("@idFornecedor", Convert.ToInt32(txtIdfornecedor.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dados atualizados com sucesso!");

                    var menu = new Despesa();
                    menu.Show(this);

                    this.Visible = false;
                }
            }
        }



        private bool ValidarCampo()
        {

            if (txtIdfornecedor.Text == "")
            {
                MessageBox.Show("O campo id do fornecedor é obrigatório.");
                txtIdfornecedor.Focus();
                return true;
            }


            if (txtQuantidade.Text == "")
            {
                MessageBox.Show("O campo quantidade é obrigatório.");
                txtQuantidade.Focus();
                return true;
            }



            if (txtProduto.Text == "")
            {
                MessageBox.Show("O campo produto é obrigatório.");
                txtProduto.Focus();
                return true;
            }

            if(txtValor.Text == "")
            {
                MessageBox.Show("O campo valor é obrigatório.");
                txtValor.Focus();
                return true;
            }


            return false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            if (ValidarCampo() == false)
            {
                var resultado = MessageBox.Show("Você tem certeza que deseja adicionar essa despesa?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                        using (var conectar = new SqlConnection(bdonlygreen))
                        {
                            conectar.Open();

                            // Verificando se o idFornecedor existe
                            string checkQuery = "SELECT COUNT(*) FROM tb_Fornecedor WHERE id = @idFornecedor;";
                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conectar))
                            {
                                checkCmd.Parameters.AddWithValue("@idFornecedor", txtIdfornecedor.Text);
                                int count = (int)checkCmd.ExecuteScalar();

                                if (count == 0)
                                {
                                    MessageBox.Show("Fornecedor não encontrado. Verifique o ID.");
                                    return;
                                }
                            }

                            // Se o fornecedor existe, prosseguir com a inserção
                            string add = "INSERT INTO tb_Despesa (pk_idFornecedor, quantidade, dregistro, produto, valor) " +
                                         "VALUES (@idFornecedor, @quantidade, GETDATE(), @produto, @valor);";

                            using (SqlCommand cmd = new SqlCommand(add, conectar))
                            {
                                cmd.Parameters.AddWithValue("@idFornecedor", txtIdfornecedor.Text);
                                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
                                cmd.Parameters.AddWithValue("@produto", txtProduto.Text);
                                cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtValor.Text));

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Despesa adicionada com sucesso.");

                                var menu = new Despesa();
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




        private void tbDespesa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Verifica se o campo do ID da despesa está preenchido
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, informe o ID da despesa a ser deletada.");
                return;
            }

            var resultado = MessageBox.Show("Você tem certeza que deseja deletar essa despesa?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                try
                {
                    string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                    using (var conectar = new SqlConnection(bdonlygreen))
                    {
                        conectar.Open();
                        string delete = "DELETE FROM tb_Despesa WHERE id = @id;"; 

                        using (SqlCommand cmd = new SqlCommand(delete, conectar))
                        {
                            cmd.Parameters.AddWithValue("@id", txtId.Text);

                            int id = cmd.ExecuteNonQuery();

                            if (id > 0)
                            {
                                MessageBox.Show("Despesa deletada com sucesso.");
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma despesa encontrada com o ID informado.");
                            }
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
}
