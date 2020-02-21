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
                string queryList = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

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
                            Sobrenome = rdr["Sobrenome"].ToString(),

                            // Atribui à propriedade DataNascimento o valor da coluna "DataNascimento" da tabela do banco
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o funcionario com os dados na tabela Funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            //retorna a lista de funcionarios
            return funcionarios;
        }

        /// <summary>
        /// Atualiza os dados de um funcionario passando o Id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionario">Objeto funcionario que será atualizado</param>
        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DataNascimento WHERE IdFuncionario = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um funcionario pelo id
        /// </summary>
        /// <param name="id">id do funcionario que será buscado</param>
        /// <returns>Retorna o funcionario buscado</returns>
        public FuncionarioDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE IdFuncionario = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto funcionario
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna "IdFuncionario" da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Nome = rdr["Nome"].ToString(),

                            // Atribui à propriedade Sobrenome o valor da coluna "Sobrenome" da tabela do banco
                            Sobrenome = rdr["Sobrenome"].ToString(),

                            // Atribui à propriedade DataNascimento o valor da coluna "DataNascimento" da tabela do banco
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Retorna o funcionario com os dados obtidos
                        return funcionario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Deleta um funcionario
        /// </summary>
        /// <param name="id">Id do funcionario que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando... comando sem conculta, não quero mostrar nada, só enviar 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Metodo para inserir um novo funcionario
        /// </summary>
        /// <param name="funcionario">Objeto funcionario que será cadastrado</param>
        public void Inserir(FuncionarioDomain funcionario)
        {
            // String para fazer a conexão com o banco de dados
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Query que será executada
                string queryInsert = "INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento) VALUES (@Nome, @Sobrenome, @DataNascimento)";

                // Comando que faz a junção da Query e a conexao
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                // Valor do Parametro que será coletado
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);

                // Abre a conexão com o banco de dados
                con.Open();

                //Executa o comando
                cmd.ExecuteNonQuery();
            }
        }
    }
}
