using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mysqlx.Crud;

namespace onlygreen.teste
{
    [TestClass]
    public class supervisorteste
    {
        [TestMethod]
        public void TesteInsertUsuario()
        {
            
            var supervisor = new classSupervisor();
            var usuario = new classUsuario
            {
                nome = "Teste Nome",
                cpf = "12345678901",
                telefone = "123456789",
                email = "teste@teste.com",
                rua = "Rua Teste",
                nrua = "100",
                bairro = "Bairro Teste",
                cidade = "Cidade Teste",
                estado = "Estado Teste",
                cep = "12345678",
                ulogar = "ulogin",
                senha = "senha123",
                tipousuario = "Supervisor",
                situacao = "Ativo"
            };

           
            try
            {
                supervisor.INSERTusuario(usuario);
                Assert.IsTrue(true, "Usuário inserido com sucesso.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Erro ao inserir usuário: " + ex.Message);
            }
        }

        [TestMethod]
        public void TesteUpdateUsuario()
        {
           
            var supervisor = new classSupervisor();
            var usuario = new classUsuario
            {
                nome = "Nome Atualizado",
                cpf = "12345678901", 
                telefone = "987654321",
                email = "atualizado@teste.com",
                rua = "Rua Atualizada",
                nrua = "200",
                bairro = "Bairro Atualizado",
                cidade = "Cidade Atualizada",
                estado = "Estado Atualizado",
                cep = "87654321",
                ulogar = "ulogin", 
                senha = "novaSenha123",
                tipousuario = "Supervisor",
                situacao = "Inativo"
            };

            
            try
            {
                supervisor.UPDATEusuario(usuario);
                Assert.IsTrue(true, "Usuário atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Erro ao atualizar usuário: " + ex.Message);
            }
        }
    }
}




