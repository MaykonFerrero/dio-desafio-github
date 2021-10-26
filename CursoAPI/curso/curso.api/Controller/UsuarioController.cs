using curso.api.Models.Usuaios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
 
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {

            return Created("",loginViewModelInput);
        }

        [HttpGet]
        public string Get()
        {
            return "Teste...";
        }
        

    }
}
