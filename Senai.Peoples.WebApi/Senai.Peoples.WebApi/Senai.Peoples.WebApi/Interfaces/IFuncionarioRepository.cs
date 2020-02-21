using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositorio Funcionario
    /// </summary>
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Retorna uma lista de funcionarios cadastrados</returns>
        List<FuncionarioDomain> Listar();

        /// <summary>
        /// Faz a busca de um funcionario pelo Id
        /// </summary>
        /// <param name="id">Id do funcionario</param>
        /// <returns>Retorna o funcionario buscado pelo Id</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um funcionario pelo Id
        /// </summary>
        /// <param name="id">Id do funcionario que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza o registro de um funcionario através do Id informado no corpo
        /// </summary>
        /// <param name="funcionario">Objeto funcionario que sera atualizado</param>
        void AtualizarIdCorpo(FuncionarioDomain funcionario);

        /// <summary>
        /// Adiciona um novo funcionario
        /// </summary>
        /// <param name="funcionario">Objeto funcionario que será adicionado</param>
        void Inserir(FuncionarioDomain funcionario);

        
    }
}
