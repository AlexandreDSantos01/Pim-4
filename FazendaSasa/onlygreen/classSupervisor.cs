using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlygreen
{
    public class classSupervisor : classCRUDsupervisor
    {
        public override void INSERTusuario(classUsuario u)
        {
            try
            {
                string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                using (var conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();
                    var command = new SqlCommand("INSERT INTO tb_Usuario (nome, cpf, telefone, email, rua, nrua, bairro, cidade, estado, cep, ulogar, senha, tipousuario, situacao) " +
                                                 "VALUES (@nome, @cpf, @telefone, @email, @rua, @nrua, @bairro, @cidade, @estado, @cep, @ulogar, @senha, @tipousuario, @situacao)", conectar);

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
                MessageBox.Show("Cpf ou nome já existe no banco de dados. Altere e tente novamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        public override void UPDATEusuario(classUsuario u)
        {
            try
            {
                string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                using (SqlConnection conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();

                    // Constrói a query dinamicamente
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
                                 "situacao = @situacao";

                    // Adiciona o campo de senha apenas se ele não for nulo ou vazio
                    if (!string.IsNullOrEmpty(u.senha))
                    {
                        sql += ", senha = @senha";
                    }

                    sql += " WHERE ulogar = @ulogar;";

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
                        cmd.Parameters.AddWithValue("@tipousuario", u.tipousuario);
                        cmd.Parameters.AddWithValue("@situacao", u.situacao);

                        // Adiciona o parâmetro de senha apenas se necessário
                        if (!string.IsNullOrEmpty(u.senha))
                        {
                            cmd.Parameters.AddWithValue("@senha", u.senha);
                        }

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


        public override void DELETE()
        {
            //Não há
        }

        public override DataTable SELECT(int id)
        {
            DataTable retornarID = new DataTable();

            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var procurar = new SqlCommand("SELECT * FROM tb_Usuario WHERE id = @id", conectar))
                {
                    procurar.Parameters.AddWithValue("@id", id);

                    using (var resp = new SqlDataAdapter(procurar))
                    {
                        resp.Fill(retornarID); // Preenche o DataTable
                    }
                }
            }

            // Verifica se o DataTable tem linhas
            if (retornarID.Rows.Count == 0)
            {
                MessageBox.Show("Usuário não encontrado.");
            }
            return retornarID;
        }


    }
}
