using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    /// <summary>
    /// Repositorio dos funcionarios que herda os metodos criados na interface
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor identificado no banco de dados
        /// initial catalog = Nome do banco de dados
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        /// //private string StringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=Filmes; integrated security=true";
        private string stringConexao = "Data Source=N-1S-DEV-12\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Metodo para listar todos os funcionarios
        /// </summary>
        /// <returns></returns>
        public List<FuncionarioDomain> Listar()
        {
            // cria um objeto funcionario do tipo lista onde serão armazenados todos os funcionarios
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Estabelecer a conexão com o banco de dados, passando a string de conexão declarada acima
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declarar a instrução que será executada
                string queryList = "SELECT Nome, Sobrenome FROM Funcionarios";

                // Abrir conexão com o banco de dados
                con.Open();

                // Declarar o SqlDataReader para fazer a leitura da tabela do banco
                SqlDataReader rdr;

                // Declarar o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryList, con))
                {
                    // Armazena no objeto rdr as informações que foram lidas da tabela
                    rdr = cmd.ExecuteReader();

                    // Laço que faz a leitura dos registros dentro do objeto rdr
                    while (rdr.Read())
                    {
                        //Cria um objeto funcionario do tipo FuncionarioDomain para armazenar os dados que serão mostrados
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //Atribui a propriedade IdFuncionario os dados da coluna IdFuncionario da tabela Funcionarios
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            //Atribui a propriedade Nome os dados da coluna Nome da tabela Funcionarios
                            Nome = rdr["Nome"].ToString(),

                            //Atribui a propriedade Sobrenome os dados da coluna Sobrenome da tabela Funcionarios
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Adiciona o funcionario com os dados na tabela Funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            //retorna a lista de funcionarios
            return funcionarios;
        }

        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            throw new NotImplementedException();
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(FuncionarioDomain funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
