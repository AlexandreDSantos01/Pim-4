using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using System.Data.SqlClient;



namespace onlygreen
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();

            check1.Checked = true;
            check2.Checked = true;
        }

        // Método para carregar os dados no DataGridView
        private void CarregarDados()
        {
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Usuario", conectar))
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
                    tbUsuario.DataSource = filtrar;
                }
            }
        }


        //Método para pegar id
        public void SetId(string id)
        {
            txtId.Text = id;
        }
        //Método para pegar id fim   

        // Método add usuário
        public static void AddUser(classUsuario u)
        {  
            try
            {
                string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                using (var conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();
                    var command = new SqlCommand("INSERT INTO tb_Usuario (nome, cpf, telefone, email, rua, nrua, bairro, cidade, estado, cep, ulogar, senha, tipousuario, situacao) VALUES (@nome, @cpf, @telefone, @email, @rua, @nrua, @bairro, @cidade, @estado, @cep, @ulogar, @senha, @tipousuario, @situacao)", conectar);

                    command.Parameters.AddWithValue("@nome", u.nome);
                    command.Parameters.AddWithValue("@cpf", u.cpf);
                    command.Parameters.AddWithValue("@telefone", u.telefone);
                    command.Parameters.AddWithValue("@email", u.email);
                    command.Parameters.AddWithValue("@rua", u.rua);
                    command.Parameters.AddWithValue("@nrua", u.nrua);
                    command.Parameters.AddWithValue("@bairro", u.bairro);
                    command.Parameters.AddWithValue("@cidade", u.cidade);
                    command.Parameters.AddWithValue("@estado", u.estado);
                    command.Parameters.AddWithValue("@cep", u.cep);
                    command.Parameters.AddWithValue("@ulogar", u.ulogar);
                    command.Parameters.AddWithValue("@senha", u.senha);
                    command.Parameters.AddWithValue("@tipousuario", u.tipousuario);
                    command.Parameters.AddWithValue("@situacao", u.situacao);

                    command.ExecuteNonQuery();
                
                    MessageBox.Show("Usuário adicionado com sucesso.");
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Usuário, cpf ou nome já existe no banco de dados. Altere e tente novamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        // Método add usuário fim

        //Método att usuário
        public static void AttUser(classUsuario u)
        {
            try
            {
                string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                using (SqlConnection conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();

                    string sql = "UPDATE tb_Usuario SET " +
                                 "nome = @nome, " +
                                 "telefone = @telefone, " +
                                 "email = @email, " +
                                 "rua = @rua, " +
                                 "nrua = @nrua, " +
                                 "bairro = @bairro, " +
                                 "cidade = @cidade, " +
                                 "estado = @estado, " +
                                 "cep = @cep, " +
                                 "tipousuario = @tipousuario, " +
                                 "situacao = @situacao, " +
                                 "senha = @senha " +
                                 "WHERE ulogar = @ulogar;";


                    using (SqlCommand cmd = new SqlCommand(sql, conectar))
                    {
                        cmd.Parameters.AddWithValue("@nome", u.nome);
                        cmd.Parameters.AddWithValue("@cpf", u.cpf);
                        cmd.Parameters.AddWithValue("@telefone", u.telefone);
                        cmd.Parameters.AddWithValue("@email", u.email);
                        cmd.Parameters.AddWithValue("@rua", u.rua);
                        cmd.Parameters.AddWithValue("@nrua", u.nrua);
                        cmd.Parameters.AddWithValue("@bairro", u.bairro);
                        cmd.Parameters.AddWithValue("@cidade", u.cidade);
                        cmd.Parameters.AddWithValue("@estado", u.estado);
                        cmd.Parameters.AddWithValue("@cep", u.cep);
                        cmd.Parameters.AddWithValue("@ulogar", u.ulogar);
                        cmd.Parameters.AddWithValue("@senha", u.senha);
                        cmd.Parameters.AddWithValue("@tipousuario", u.tipousuario);
                        cmd.Parameters.AddWithValue("@situacao", u.situacao);
                       
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuário atualizado com sucesso."); 

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        //Método att usuário

        //Método validar campos usuário
        private bool ValidarCampoUsuario()
        {
            //Campo nome
            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo nome é obrigatório.");
                txtNome.Focus();
                return true;
            }

            //Campo cpf
            if (txtCPF.Text == "")
            {
                MessageBox.Show("O campo cpf é obrigatório.");
                txtCPF.Focus();
                return true;
            }

            //Campo telefone
            if (txtTelefone.Text == "")
            {
                MessageBox.Show("O campo telefone é obrigatório.");
                txtTelefone.Focus();
                return true;
            }

            //Campo email
            if (txtEmail.Text == "")
            {
                MessageBox.Show("O campo email é obrigatório.");
                txtEmail.Focus();
                return true;
            }

            //Campo rua
            if (txtRua.Text == "")
            {
                MessageBox.Show("O campo rua é obrigatório.");
                txtRua.Focus();
                return true;
            }

            //Campo nrua
            if (txtNrua.Text == "")
            {
                MessageBox.Show("O campo número da rua é obrigatório.");
                txtNrua.Focus();
                return true;
            }

            //Campo bairro
            if (txtBairro.Text == "")
            {
                MessageBox.Show("O campo bairro é obrigatório.");
                txtBairro.Focus();
                return true;
            }

            //Campo cidade
            if (txtCidade.Text == "")
            {
                MessageBox.Show("O campo cidade é obrigatório.");
                txtCidade.Focus();
                return true;
            }

            //Campo estado
            if (txtEstado.Text == "")
            {
                MessageBox.Show("O campo estado é obrigatório.");
                txtEstado.Focus();
                return true;
            }

            //Campo cep
            if (txtCEP.Text == "")
            {
                MessageBox.Show("O campo cep é obrigatório.");
                txtCEP.Focus();
                return true;
            }

            //Campo usuário
            if (txtLogin.Text == "")
            {
                MessageBox.Show("O campo usuário é obrigatório.");
                txtLogin.Focus();
                return true;
            }

            //Campo senha
            if (txtSenha.Text == "")
            {
                MessageBox.Show("O campo senha é obrigatório.");
                txtSenha.Focus();
                return true;
            }

            //Campo check permissões
            if (rbFinanceiro.Checked == false && rbProdutor.Checked == false && rbSuprimento.Checked == false && rbVendedor.Checked == false && rbSupervisor.Checked == false && rbTodos.Checked == false)
            {
                MessageBox.Show("As permissões do usuário é obrigatório.");
                rbSupervisor.Focus();
                return true;
            }

            return false;
        }

        //Método validar campos usuário fim


        private void Usuario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdonlygreenDataSet4.tb_Usuario'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_UsuarioTableAdapter4.Fill(this.bdonlygreenDataSet4.tb_Usuario);


            tbUsuario.Columns[0].Width = 50;
            tbUsuario.Columns[1].Width = 130;
            tbUsuario.Columns[2].Width = 150;
            tbUsuario.Columns[3].Width = 105;
            tbUsuario.Columns[4].Width = 90;


        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja sair da gestão de usuário?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Home();
                menu.Show(this);

                this.Visible = false;
            }
        }


        //Setar usuário
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoUsuario() == false)
            {
                if (checkAtivo.Checked == false)
                {
                   MessageBox.Show("Você está adicionando novo usuário como inativo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var resultado = MessageBox.Show("Você tem certeza que deseja adicionar esse usuário?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    string senha = txtSenha.Text;
                    string senhaHash = BCrypt.Net.BCrypt.EnhancedHashPassword(senha, 13);
                    
                    Console.WriteLine($"Hash gerado: {senhaHash}");

                    classUsuario classusuario = new classUsuario();


                    classusuario.nome = txtNome.Text;
                    classusuario.cpf = txtCPF.Text;
                    classusuario.telefone = txtTelefone.Text;
                    classusuario.email = txtEmail.Text;
                    classusuario.rua = txtRua.Text;
                    classusuario.nrua = txtNrua.Text;
                    classusuario.bairro = txtBairro.Text;
                    classusuario.cidade = txtCidade.Text;
                    classusuario.estado = txtEstado.Text;
                    classusuario.cep = txtCEP.Text;
                    classusuario.ulogar = txtLogin.Text;
                    classusuario.senha = senhaHash;

                    //Tipo Usuário
                    if (rbFinanceiro.Checked)
                    {
                        classusuario.tipousuario = "Financeiro";
                    }
                    else if (rbProdutor.Checked)
                    {
                        classusuario.tipousuario = "Produtor";
                    }
                    else if (rbSuprimento.Checked)
                    {
                        classusuario.tipousuario = "Suprimento";
                    }
                    else if (rbVendedor.Checked)
                    {
                        classusuario.tipousuario = "Vendedor";
                    }
                    else if (rbSupervisor.Checked)
                    {
                        classusuario.tipousuario = "Supervisor";
                    }
                    else if (rbTodos.Checked)
                    {
                        classusuario.tipousuario = "Todos";
                    }

                    //Situação
                    if (checkAtivo.Checked)
                    {
                        classusuario.situacao = "Ativo";
                    }
                    else
                    {
                        classusuario.situacao = "Inativo";
                    }

                    AddUser(classusuario);

                    Console.WriteLine($"Senha fornecida: {senha}");
                    Console.WriteLine($"Hash armazenado: {senhaHash}");

                    var menu = new Usuario();
                    menu.Show(this);
                    this.Visible = false;
                }
                return;
            }
        }
        //Setar usuário fim

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetterOrDigit(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas letras ou números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private DataTable GetUserDataById(int userId)
        {
            DataTable dt = new DataTable();
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var command = new SqlCommand("SELECT * FROM tb_Usuario WHERE id = @id", conectar))
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

        private void btnAlterar_Click(object sender, EventArgs e)
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
                using (var command = new SqlCommand("SELECT COUNT(*) FROM tb_Usuario WHERE id = @id", conectar))
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
                txtCPF.Text = dt.Rows[0].Field<string>("cpf");
                txtTelefone.Text = dt.Rows[0].Field<string>("telefone");
                txtEmail.Text = dt.Rows[0].Field<string>("email");
                txtRua.Text = dt.Rows[0].Field<string>("rua");
                txtNrua.Text = dt.Rows[0].Field<string>("nrua");
                txtBairro.Text = dt.Rows[0].Field<string>("bairro");
                txtCidade.Text = dt.Rows[0].Field<string>("cidade");
                txtEstado.Text = dt.Rows[0].Field<string>("estado");
                txtCEP.Text = dt.Rows[0].Field<string>("cep");
                txtLogin.Text = dt.Rows[0].Field<string>("ulogar");
                txtSenha.Text = dt.Rows[0].Field<string>("senha");
                // Preenche a situação do usuário
                if (dt.Rows[0].Field<string>("situacao") == "Ativo")
                {
                    checkAtivo.Checked = true;
                }
                else
                {
                    checkAtivo.Checked = false;
                }

                // Preenche o tipo de usuário
                string tipoUsuario = dt.Rows[0].Field<string>("tipousuario");
                switch (tipoUsuario)
                {
                    case "Financeiro":
                        rbFinanceiro.Checked = true;
                        break;
                    case "Produtor":
                        rbProdutor.Checked = true;
                        break;
                    case "Suprimento":
                        rbSuprimento.Checked = true;
                        break;
                    case "Vendedor":
                        rbVendedor.Checked = true;
                        break;
                    case "Supervisor":
                        rbSupervisor.Checked = true;
                        break;
                    case "Todos":
                        rbTodos.Checked = true;
                        break;
                    default:
                        // Se não houver correspondência, desmarque todos ou faça outra ação
                        rbFinanceiro.Checked = false;
                        rbProdutor.Checked = false;
                        rbSuprimento.Checked = false;
                        rbVendedor.Checked = false;
                        rbSupervisor.Checked = false;
                        rbTodos.Checked = false;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Não foi possível carregar os dados do usuário.");
            }
        }


        private void Limpar()
        {
            txtId.Clear();
            txtCPF.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtRua.Clear();
            txtNrua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtSenha.Clear();
            txtEstado.Clear();
            txtCEP.Clear();
            txtLogin.Clear();
            rbFinanceiro.Checked = false;
            rbProdutor.Checked = false;
            rbSuprimento.Checked = false;
            rbVendedor.Checked = false;
            rbSupervisor.Checked = false;
            rbTodos.Checked = false;
            checkAtivo.Checked = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoUsuario() == false)
            {
                var resultado = MessageBox.Show("Você tem certeza que deseja alterar esse usuário?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    //hash
                    string senha = txtSenha.Text;
                    string senhaHash = BCrypt.Net.BCrypt.EnhancedHashPassword(senha, 13);
                    //hash fim

                    classUsuario classusuario = new classUsuario();


                    classusuario.nome = txtNome.Text;
                    classusuario.cpf = txtCPF.Text;
                    classusuario.telefone = txtTelefone.Text;
                    classusuario.email = txtEmail.Text;
                    classusuario.rua = txtRua.Text;
                    classusuario.nrua = txtNrua.Text;
                    classusuario.bairro = txtBairro.Text;
                    classusuario.cidade = txtCidade.Text;
                    classusuario.estado = txtEstado.Text;
                    classusuario.cep = txtCEP.Text;
                    classusuario.ulogar = txtLogin.Text;
                    classusuario.senha = senhaHash;

                    //Tipo Usuário
                    if (rbFinanceiro.Checked)
                    {
                        classusuario.tipousuario = "Financeiro";
                    }
                    else if (rbProdutor.Checked)
                    {
                        classusuario.tipousuario = "Produtor";
                    }
                    else if (rbSuprimento.Checked)
                    {
                        classusuario.tipousuario = "Suprimento";
                    }
                    else if (rbVendedor.Checked)
                    {
                        classusuario.tipousuario = "Vendedor";
                    }
                    else if (rbSupervisor.Checked)
                    {
                        classusuario.tipousuario = "Supervisor";
                    }
                    else if (rbTodos.Checked)
                    {
                        classusuario.tipousuario = "Todos";
                    }

                    //Situação
                    if (checkAtivo.Checked)
                    {
                        classusuario.situacao = "Ativo";
                    }
                    else
                    {
                        classusuario.situacao = "Inativo";
                    }

                    AttUser(classusuario);

                    var menu = new Usuario();
                    menu.Show(this);
                    this.Visible = false;

                }
                return;
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
                    "SELECT * FROM tb_Usuario WHERE nome LIKE @pesquisar OR " +
                    "nome LIKE @pesquisar OR " +
                    "cpf LIKE @pesquisar OR " +
                    "tipousuario LIKE @pesquisar OR " +
                    "situacao LIKE @pesquisar OR " +
                     "id LIKE @pesquisar", conectar))
                {
                    cmd.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        tbUsuario.DataSource = dt;
                    }
                }
            }

        }


//IGNORAR
        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
//IGNORAR


        //FILTRO
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}

