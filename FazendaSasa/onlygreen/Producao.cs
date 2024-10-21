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
    public partial class Producao : Form
    {
        public Producao()
        {
            InitializeComponent();
        }

        private void Producao_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdonlygreenDataSet6.tb_Producao'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_ProducaoTableAdapter1.Fill(this.bdonlygreenDataSet6.tb_Producao);


            tbProducao.Columns[0].Width = 50;
            tbProducao.Columns[1].Width = 130;
            tbProducao.Columns[2].Width = 120;
            tbProducao.Columns[3].Width = 105;
            tbProducao.Columns[4].Width = 105;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text))
            {
                MessageBox.Show("Por favor, insira um nome ou id.");
                txtPesquisar.Focus();
                return;
            }

            string pesquisar = txtPesquisar.Text;
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {

                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tb_Producao WHERE nome LIKE @pesquisar OR " +
                    "nome LIKE @pesquisar OR " +
                    "id LIKE @pesquisar", conectar))
                {
                    cmd.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        tbProducao.DataSource = dt;
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da gestão de produção?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Home();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private DataTable GetId(int userId)
        {
            DataTable dt = new DataTable();
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var command = new SqlCommand("SELECT * FROM tb_Producao WHERE id = @id", conectar))
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
                using (var command = new SqlCommand("SELECT COUNT(*) FROM tb_Producao WHERE id = @id", conectar))
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
                txtNome.Text = dt.Rows[0].Field<string>("nome");
                txtQuantidade.Text = dt.Rows[0].Field<int>("quantidade").ToString();
                DateTime estimativa = dt.Rows[0].Field<DateTime>("estimativa");
                txtEstimativa.Text = estimativa.ToString("dd/MM/yyyy");

                DateTime dregistro = dt.Rows[0].Field<DateTime>("dregistro");
                txtRegistro.Text = dregistro.ToString("dd/MM/yyyy");
            }
        }

        private bool ValidarCampoProducao()
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



            if (txtEstimativa.Text == "")
            {
                MessageBox.Show("O campo estimativa da colheita é obrigatório.");
                txtEstimativa.Focus();
                return true;
            }


            return false;
        }



        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoProducao() == false)
            {
                var resultado = MessageBox.Show("Você tem certeza que deseja adicionar essa produção?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                        using (var conectar = new SqlConnection(bdonlygreen))
                        {
                            conectar.Open();

                            // Validação da data de estimativa
                            DateTime estimativa;
                            if (!DateTime.TryParse(txtEstimativa.Text, out estimativa) || estimativa < DateTime.Today)
                            {
                                MessageBox.Show("A data estimativa é inválida ou está no passado.");
                                return;
                            }

                            string add = "INSERT INTO tb_Producao (nome, quantidade, dregistro, estimativa) " +
                                         "VALUES (@nome, @quantidade, GETDATE(), @estimativa);";

                            using (SqlCommand cmd = new SqlCommand(add, conectar))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
                                cmd.Parameters.AddWithValue("@estimativa", estimativa); // Adiciona a data estimativa válida

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Produção adicionada com sucesso.");

                                var menu = new Producao();
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


        private void Limpar()
        {
            txtId.Clear();
            txtNome.Clear();
            txtQuantidade.Clear();
            txtEstimativa.Clear();
            txtRegistro.Clear();    
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja cancelar esta produção?", "Confirmação",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                using (var conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TB_Producao WHERE id = @id", conectar))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);

                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Produção cancelada com sucesso!");

                                var menu = new Producao();
                                menu.Show(this);

                                this.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro encontrado com esse ID.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao cancelar a produção: " + ex.Message);
                        }
                    }
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
                using (var cmd = new SqlCommand("UPDATE tb_Producao SET nome = @nome, quantidade = @quantidade, estimativa = @estimativa WHERE id = @id", conectar))
                {
                    cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(txtQuantidade.Text));
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                    DateTime estimativa;
                    try
                    {
                        // Validação da data de estimativa
                        if (!DateTime.TryParse(txtEstimativa.Text, out estimativa) || estimativa < DateTime.Today)
                        {
                            MessageBox.Show("A data estimativa é inválida ou está no passado.");
                            return;
                        }
                        cmd.Parameters.AddWithValue("@estimativa", estimativa); // Adiciona a data estimativa válida
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida.");
                        return;
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dados atualizados com sucesso!");

                        var menu = new Producao();
                        menu.Show(this);
                        this.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar os dados: " + ex.Message);
                    }
                }
            }
        }


    }
}
