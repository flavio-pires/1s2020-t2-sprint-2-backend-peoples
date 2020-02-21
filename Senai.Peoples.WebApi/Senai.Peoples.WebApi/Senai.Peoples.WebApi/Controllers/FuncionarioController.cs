using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos funcionarios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _funcionarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Retorna uma lista dos funcionarios cadastrados</returns>
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            // Faz a chamada para o metodo .Listar();
            return _funcionarioRepository.Listar();
        }

        /// <summary>
        /// Atualiza um funcionario
        /// </summary>
        /// <param name="funcionarioAtualizado">Objeto funcionario que será atualizado</param>
        /// <returns>Retorna Status Code Ok e uma mensagem personalizada </returns>
        [HttpPut]
        public IActionResult PutIdCorpo(FuncionarioDomain funcionarioAtualizado)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.IdFuncionario);

            // Condição que verifica se o funcionario que será atualizado existe no banco de dados
            if(funcionarioBuscado == null)
            {
                // Se não for encontrado, retorna um BadRequest e uma mensagem personalizada
                return BadRequest("Funcionário não encontrado");
            }

            else
            {
                // Faz a chamada para o método .AtualizarIdCorpo();
                _funcionarioRepository.AtualizarIdCorpo(funcionarioAtualizado);

                // Retorna um status code ok com uma mensagem personalizada
                return Ok("Dados atualizados");
            }
        }

        /// <summary>
        /// Buscar um funcionario pelo id
        /// </summary>
        /// <param name="id">Id do funcionario buscado</param>
        /// <returns>Retorna o funcionario buscado pelo id</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionado buscado pelo id do banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Condição que verifica se o id do funcionario existe no banco
            if (funcionarioBuscado == null)
            {
                //Caso não exista, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum funcionário encontrado");
            }

            // Caso seja encontrado, retorna o funcionario buscado
            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// Exclui um funcionario
        /// </summary>
        /// <param name="id">Id do funcionario que será excluido</param>
        /// <returns>Retorna Status Code Ok e uma mensagem personalizada</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o metodo .Deletar();
            _funcionarioRepository.Deletar(id);

            // Retorna um status code Ok com uma mensagem personalizada
            return Ok("Funcionario excluído");
        }

        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">Objeto que irá armazenar o funcionario recebido na requisição</param>
        /// <returns>Retorna o Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            // Faz a chamada para o metodo .Inserir();
            _funcionarioRepository.Inserir(novoFuncionario);

            // Retorna um Status Code 201 - Created e uma mensagem personalizada
            return Ok("Novo funcionário cadastrado");
        }
    }
}