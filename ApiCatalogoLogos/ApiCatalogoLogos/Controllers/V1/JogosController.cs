using ApiCatalogoLogos.Exceptions;
using ApiCatalogoLogos.InputModel;
using ApiCatalogoLogos.Services;
using ApiCatalogoLogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoLogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        /// <summary>
        /// Buscar todos os jogos de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os jogos sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de registros por página. Mínimo 1 e máximo 50</param>
        /// <response code="200">Retorna a lista de jogos</response>
        /// <response code="204">Caso não haja jogos</response>   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {


                var jogos = await _jogoService.Obter(pagina, quantidade);

                if (jogos.Count() == 0)
                    return NoContent();

                return Ok(jogos);
           
            
        }





        /// <summary>
        /// Buscar todos o jogo por id
        /// </summary>
        /// <remarks>
        /// Não é possível retornar o jogo sem um id Válido
        /// </remarks>
        /// <param name="idJogo">Indica qual o id do jogo a ser consultado</param>
        /// <response code="200">Retorna o jogo cujo id foi digitado</response>
        /// <response code="204">Caso o id não seja válido</response>  
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);
            if (jogo == null)
            {
                return NoContent();
            }
            return Ok(jogo);
        }

        /// <summary>
        /// Inserir Novo jogo
        /// </summary>
        /// <remarks>
        /// Não é possível inserir um jogo sem ter os campos preenchidos corretamente
        /// </remarks>
        /// <param name="jogoInputModel">Indica as informações sobre o jogo a serem inseridas</param>
        /// <response code="200">Caso o jogo for criado corretamente</response>
        /// <response code="204">Caso o jogo já exista no banco ou faltar informações</response> 
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            //catch(Exception ex)
            {

                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora no diretório");
            }
        }

        /// <summary>
        /// Editar informações de um jogo em específico
        /// </summary>
        /// <remarks>
        /// Não é possível atualizar o jogo sem um id Válido
        /// </remarks>
        /// <param name="idJogo">Indica qual o id do jogo a ser consultado</param>
        /// <param name="jogoInputModel">Indica as informações sobre o jogo que podem ser modificadas</param>
        /// <response code="200">Caso o jogo for modificado corretamente</response>
        /// <response code="204">Caso o id não seja válido ou o jogo foi modificado incorretamente</response> 
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid idJogo,[FromBody]JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);
                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
            
        }


        /// <summary>
        /// Editar preço de um jogo em específico
        /// </summary>
        /// <remarks>
        /// Não é possível modificar o preço do jogo sem um id Válido
        /// </remarks>
        /// <param name="idJogo">Indica qual o id do jogo a ser consultado</param>
        /// <param name="preco">Indica o novo preço</param>
        /// <response code="200">Caso o preço do jogo for modificado corretamente</response>
        /// <response code="204">Caso o id não seja válido ou o preço do jogo foi modificado incorretamente</response> 
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid idJogo,[FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);
                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
           // catch (Exception ex)
            {
                return NotFound("Nao existe este jogo");
            }
        }


        /// <summary>
        /// Deletar um jogo em específico
        /// </summary>
        /// <remarks>
        /// Não é possível deletar o jogo sem um id Válido
        /// </remarks>
        /// <param name="idJogo">Indica qual o id do jogo a ser consultado</param>
        /// <response code="200">Caso o jogo for deletado</response>
        /// <response code="204">Caso o id não seja válido </response> 
        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute]Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);
                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            //catch (Exception ex)
            {
                return NotFound("Nao existe este jogo");
            }
        }

    }
}
