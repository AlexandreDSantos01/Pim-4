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
    public partial class Financeiro : Form
    {
        public Financeiro()
        {
            InitializeComponent();
        }

        private void Financeiro_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdonlygreenDataSet18.tb_Financeiro'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_FinanceiroTableAdapter.Fill(this.bdonlygreenDataSet18.tb_Financeiro);

            tbFinanceiro.Columns[0].Width = 50;
            tbFinanceiro.Columns[1].Width = 120;
            tbFinanceiro.Columns[2].Width = 120;
            tbFinanceiro.Columns[3].Width = 120;
            tbFinanceiro.Columns[4].Width = 100;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da gestão financeira?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

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
                MessageBox.Show("Por favor: insira um id ou nome.");
                txtPesquisar.Focus();
                return;
            }

            string pesquisar = txtPesquisar.Text;
            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {

                conectar.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tb_Financeiro WHERE id LIKE @pesquisar", conectar))
                {
                    cmd.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        tbFinanceiro.DataSource = dt;
                    }
                }
            }
        }

        private void Limpar()
        {
            txtId.Clear();
            txtAte.Clear();
            txtDe.Clear();
            txtDespesa.Clear();
            txtDregistro.Clear();
            txtVenda.Clear();
            txtLucro.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja limpar todos os campos de texto?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                Limpar();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Validação das entradas de data
            if (!DateTime.TryParse(txtDe.Text, out DateTime dataInicio) ||
                !DateTime.TryParse(txtAte.Text, out DateTime dataFim))
            {
                MessageBox.Show("Por favor, insira datas válidas.");
                txtDe.Focus();
                return;
            }

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";

            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();

                // Calcular total de despesas
                decimal totalDespesa = 0;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT SUM(valor) FROM tb_Despesa WHERE dregistro BETWEEN @dataInicio AND @dataFim", conectar))
                {
                    cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", dataFim);
                    var result = cmd.ExecuteScalar();
                    totalDespesa = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }

                // Calcular total de vendas
                decimal totalVenda = 0;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT SUM(valor) FROM tb_Venda WHERE dregistro BETWEEN @dataInicio AND @dataFim", conectar))
                {
                    cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", dataFim);
                    var result = cmd.ExecuteScalar();
                    totalVenda = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }

                // Calcular lucro
                decimal lucro = totalVenda - totalDespesa;

                // Salvar o registro na tabela tb_Financeiro
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO tb_Financeiro (diainicio, diafim, valordespesa, valorvenda, valorlucro, dregistro) VALUES (@diainicio, @diafim, @valordespesa, @valorvenda, @valorlucro, GETDATE())", conectar))
                {
                    cmd.Parameters.AddWithValue("@diainicio", dataInicio);
                    cmd.Parameters.AddWithValue("@diafim", dataFim);
                    cmd.Parameters.AddWithValue("@valordespesa", totalDespesa);
                    cmd.Parameters.AddWithValue("@valorvenda", totalVenda);
                    cmd.Parameters.AddWithValue("@valorlucro", lucro);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registro adicionado com sucesso!");

                var menu = new Financeiro();
                menu.Show(this);

                this.Visible = false;

                Limpar(); // Limpa os campos após a adição
            }
        }



        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                txtId.Focus();
                return;
            }

            int id;
            if (!int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Por favor, insira um número válido para o ID.");
                return;
            }

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT dregistro, valorlucro, diainicio, diafim, " +
                    "(SELECT SUM(valor) FROM tb_Venda WHERE dregistro BETWEEN diainicio AND diafim) AS valorvenda, " +
                    "(SELECT SUM(valor) FROM tb_Despesa WHERE dregistro BETWEEN diainicio AND diafim) AS valordespesa " +
                    "FROM tb_Financeiro WHERE id = @id", conectar))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            txtDregistro.Text = reader["dregistro"].ToString();
                            txtLucro.Text = reader["valorlucro"].ToString();
                            txtVenda.Text = reader["valorvenda"].ToString();
                            txtDespesa.Text = reader["valordespesa"].ToString();

                            
                            txtDe.Text = Convert.ToDateTime(reader["diainicio"]).ToString("yyyy-MM-dd");
                            txtAte.Text = Convert.ToDateTime(reader["diafim"]).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            MessageBox.Show("Registro não encontrado.");
                        }
                    }
                }
            }
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                txtId.Focus();
                return;
            }

            int id;
            if (!int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Por favor, insira um número válido para o ID.");
                return;
            }

            // Confirmar a exclusão
            var resultado = MessageBox.Show("Você tem certeza que deseja deletar este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado != DialogResult.Yes)
            {
                return; // O usuário cancelou a operação
            }

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM tb_Financeiro WHERE id = @id", conectar))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro deletado com sucesso!");

                        var menu = new Financeiro();
                        menu.Show(this);
                        this.Visible = false;

                        Limpar(); // Limpa os campos após a exclusão
                    }
                    else
                    {
                        MessageBox.Show("Registro não encontrado.");
                    }
                }
            }
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

        private void btnDel_Enter(object sender, EventArgs e)
        {
            btnDel.BackColor = Color.Red;
        }

        private void btnDel_Leave(object sender, EventArgs e)
        {
            btnDel.BackColor = Color.Silver;
        }

        private void txtDe_Enter(object sender, EventArgs e)
        {
            txtDe.BackColor = Color.LightBlue;
        }

        private void txtDe_Leave(object sender, EventArgs e)
        {
            txtDe.BackColor = Color.White;
        }

        private void txtAte_Enter(object sender, EventArgs e)
        {
            txtAte.BackColor = Color.LightBlue;
        }

        private void txtAte_Leave(object sender, EventArgs e)
        {
            txtAte.BackColor = Color.White;
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
