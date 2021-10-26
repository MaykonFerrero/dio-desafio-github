using course.web.mvc.Models.Curso;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.web.mvc.Service
{
    public interface ICursoService
    {
        [Post("/api/v1/cursos")]
        [Headers("Athorization: Bearer")]
        Task<CadastrarCursoViewModelOutput> Registrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput);

        [Get("/api/v1/cursos")]
        [Headers("Athorization: Bearer")]
        Task<IList<ListarCursoViewModelOutput>> Obter();
    }
}
