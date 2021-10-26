
using curso.api.Controllers;
using curso.api.Models;
using curso.api.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controller
{
    [ApiController]
    [Route("api/v1/usuario")]

    public class UsuarioController : ControllerBase
    {

        [SwaggerResponse(statusCode: 200, description : "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno", Type = typeof(ErroGenericoViewModel))]

        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new ValidaCampoViewModelOutput(
                        ModelState.SelectMany(
                            sm => sm.Value.Errors
                            )
                        .Select(
                            s=> s.ErrorMessage)));
            }
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        }


    }
}