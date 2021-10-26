using course.web.mvc.Models.Curso;
using course.web.mvc.Service;

using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.web.mvc.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class CursoController : Controller
    {
        public readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }


        
        [HttpPost]
        public async Task <IActionResult> Cadastrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput)
        {
            try
            {
                var curso = await _cursoService.Registrar(cadastrarCursoViewModelInput);
                ModelState.AddModelError("", $"O curso foi cadastrado com sucesso {curso.Nome}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }


            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }


            return View();
        }

        [Authorize]
        public async Task<IActionResult> Listar()
        {
            var cursos = await _cursoService.Obter();
           

            return View(cursos);
        }





    }
}
