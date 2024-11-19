using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace onlygreen
{
    public class classUsuario
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
        public string tipousuario;
        public string ulogar;
        public string senha;
        public string situacao;
    }

    public abstract class classCRUDsupervisor
    {
        public abstract void INSERTusuario(classUsuario u);

        public abstract void UPDATEusuario(classUsuario u);

        public abstract void DELETE();

        public abstract DataTable SELECT(int id);
    }


}
