using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlygreen
{
    public class classCliente
    {
        public Int32 id;
        public string nome;
        public string cpf;
        public string telefone;
        public string email;
        public string rua;
        public string nrua;
        public string bairro;
        public string cidade;
        public string estado;
        public string cep;
        public string situacao;

        //MÉTODO PARA ADICIONAR CLIENTE NOVO v

        public static void INSERTcliente(classCliente cliente)
        {
            try
            {
                string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                using (var conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();
                    var add = new SqlCommand("INSERT INTO tb_Cliente (nome, cpf, telefone, email, rua, nrua, bairro, cidade, estado, cep, situacao) " +
                                                 "VALUES (@nome, @cpf, @telefone, @email, @rua, @nrua, @bairro, @cidade, @estado, @cep, @situacao)", conectar);

                    add.Parameters.AddWithValue("@nome", cliente.nome);
                    add.Parameters.AddWithValue("@cpf", cliente.cpf);
                    add.Parameters.AddWithValue("@telefone", cliente.telefone);
                    add.Parameters.AddWithValue("@email", cliente.email);
                    add.Parameters.AddWithValue("@rua", cliente.rua);
                    add.Parameters.AddWithValue("@nrua", cliente.nrua);
                    add.Parameters.AddWithValue("@bairro", cliente.bairro);
                    add.Parameters.AddWithValue("@cidade", cliente.cidade);
                    add.Parameters.AddWithValue("@estado", cliente.estado);
                    add.Parameters.AddWithValue("@cep", cliente.cep);
                    add.Parameters.AddWithValue("@situacao", cliente.situacao);

                    add.ExecuteNonQuery();

                    MessageBox.Show("Cliente adicionado com sucesso.");
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

        //MÉTODO PARA ADICIONAR CLIENTE NOVO ^


        //MÉTODO PARA ATUALIZAR CLIENTE v

        public static void UPDATEcliente(classCliente cliente)
        {
            try
            {
                string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
                using (SqlConnection conectar = new SqlConnection(bdonlygreen))
                {
                    conectar.Open();

                    string sql = "UPDATE tb_Cliente SET " +
                                 "nome = @nome, " +
                                 "telefone = @telefone, " +
                                 "email = @email, " +
                                 "rua = @rua, " +
                                 "nrua = @nrua, " +
                                 "bairro = @bairro, " +
                                 "cidade = @cidade, " +
                                 "estado = @estado, " +
                                 "cep = @cep, " +
                                 "situacao = @situacao, " +
                                 "WHERE id = @id;";


                    using (SqlCommand att = new SqlCommand(sql, conectar))
                    {
                        att.Parameters.AddWithValue("@nome", cliente.nome);
                        att.Parameters.AddWithValue("@cpf", cliente.cpf);
                        att.Parameters.AddWithValue("@telefone", cliente.telefone);
                        att.Parameters.AddWithValue("@email", cliente.email);
                        att.Parameters.AddWithValue("@rua", cliente.rua);
                        att.Parameters.AddWithValue("@nrua", cliente.nrua);
                        att.Parameters.AddWithValue("@bairro", cliente.bairro);
                        att.Parameters.AddWithValue("@cidade", cliente.cidade);
                        att.Parameters.AddWithValue("@estado", cliente.estado);
                        att.Parameters.AddWithValue("@cep", cliente.cep);
                        att.Parameters.AddWithValue("@situacao", cliente.situacao);
                        att.Parameters.AddWithValue("@id", cliente.id);

                        att.ExecuteNonQuery();
                        MessageBox.Show("Cliente atualizado com sucesso.");

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao atualizar cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        //MÉTODO PARA ATUALIZAR CLIENTE ^


        //MÉTODO PARA SELECIONAR CLIENTE v
        public static DataTable SELECTcliente(int userId)
        {
            DataTable retornarID = new DataTable();

            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";

            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                using (var procurar = new SqlCommand("SELECT * FROM tb_Cliente WHERE id = @id", conectar))
                {
                    procurar.Parameters.AddWithValue("@id", userId);

                    using (var resp = new SqlDataAdapter(procurar))
                    {
                        resp.Fill(retornarID); // Preenche o DataTable
                    }
                }
            }
            return retornarID;
        }

        //MÉTODO PARA SELECIONAR CLIENTE ^


    }

    //CRIAÇÃO DA CLASSE ^

}

