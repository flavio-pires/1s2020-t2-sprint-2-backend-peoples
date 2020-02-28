using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuarios</returns>
        List<TipoUsuarioDomain> Listar();

        /// <summary>
        /// Busca um tipo de usuario através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuario que será buscado</param>
        /// <returns>Retorna um tipo de usuario buscado</returns>
        TipoUsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza um tipo de uaurio existente
        /// </summary>
        /// <param name="id">ID do tipo de usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipousuarioAtualizado que será atualizado</param>
        void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuario existente
        /// </summary>
        /// <param name="id">ID do tipo de usuario que será deletado</param>
        void Deletar(int id);
    }
}
