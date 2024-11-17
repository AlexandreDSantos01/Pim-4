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

        private void CarregarDados()
        {
            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (SqlCommand pegardados = new SqlCommand("SELECT * FROM tb_Usuario", conectar))
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


                    tbUsuario.DataSource = versituacao;
                }
            }
        }


        //Método att usuário

        //Método att usuário

        //Método validar campos usuário
        private bool ValidarCampo()
        {

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
    
            //Campo usuário
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("O campo usuário é obrigatório.");
                txtLogin.Focus();
                return true;
            }

            //Campo senha
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
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


        //Adicionar usuário
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ValidarCampo() == false)
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

                    string situacao = checkAtivo.Checked ? "Ativo" : "Inativo";
                    classusuario.situacao = situacao;

                    classSupervisor supervisor = new classSupervisor();
                    supervisor.INSERTusuario(classusuario);

                    var menu = new Usuario();
                    menu.Show(this);
                    this.Visible = false;
                }
                return;
            }
        }
        //Adicionar usuário fim

        //Tratamento de caracteres no login
        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetterOrDigit(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas letras ou números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void COUNTUsuario()
        {
            bool idExists = false;

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var procurarID = new SqlCommand("SELECT COUNT(*) FROM tb_Usuario WHERE id = @id", conectar))
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para selecionar.");
                txtId.Focus();
            }

            COUNTUsuario();

            classSupervisor supervisor = new classSupervisor();
            DataTable preencher = supervisor.SELECT(Convert.ToInt32(txtId.Text));

            if (preencher.Rows.Count > 0)
            {
                txtNome.Text = preencher.Rows[0].Field<string>("nome");
                txtCPF.Text = preencher.Rows[0].Field<string>("cpf");
                txtTelefone.Text = preencher.Rows[0].Field<string>("telefone");
                txtEmail.Text = preencher.Rows[0].Field<string>("email");
                txtRua.Text = preencher.Rows[0].Field<string>("rua");
                txtNrua.Text = preencher.Rows[0].Field<string>("nrua");
                txtBairro.Text = preencher.Rows[0].Field<string>("bairro");
                txtCidade.Text = preencher.Rows[0].Field<string>("cidade");
                txtEstado.Text = preencher.Rows[0].Field<string>("estado");
                txtCEP.Text = preencher.Rows[0].Field<string>("cep");
                txtLogin.Text = preencher.Rows[0].Field<string>("ulogar");
 
                if (preencher.Rows[0].Field<string>("situacao") == "Ativo")
                {
                    checkAtivo.Checked = true;
                }
                else
                {
                    checkAtivo.Checked = false;
                }

                string tipoUsuario = preencher.Rows[0].Field<string>("tipousuario");

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
            var resultado = MessageBox.Show("Você tem certeza que deseja limpar todos os campos de texto?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                Limpar();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, insira um ID válido para alterar.");
                txtId.Focus();
            }

            if (ValidarCampo() == false)
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

                    classSupervisor supervisor = new classSupervisor();
                    supervisor.UPDATEusuario(classusuario);

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

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";

            using (SqlConnection conectar = new SqlConnection(bdonlygreen))
            {

                conectar.Open();
                using (SqlCommand buscar = new SqlCommand(
                    "SELECT * FROM tb_Usuario WHERE nome LIKE @pesquisar OR " +
                    "nome LIKE @pesquisar OR " +
                    "cpf LIKE @pesquisar OR " +
                    "tipousuario LIKE @pesquisar OR " +
                    "situacao LIKE @pesquisar OR " +
                     "id LIKE @pesquisar", conectar))
                {
                    buscar.Parameters.AddWithValue("@pesquisar", "%" + pesquisar + "%");

                    DataTable preencher = new DataTable();

                    using (SqlDataAdapter resp = new SqlDataAdapter(buscar))
                    {
                        resp.Fill(preencher);
                        tbUsuario.DataSource = preencher;
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

        private void btnSalvar_Enter(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.Orange;
        }

        private void btnSalvar_Leave(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.Silver;
        }


        private void txtLogin_Enter(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.LightBlue;
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.White;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue;
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.White;
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

