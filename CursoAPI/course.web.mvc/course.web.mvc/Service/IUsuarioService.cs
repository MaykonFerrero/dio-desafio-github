using course.web.mvc.Models.Usuario;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.web.mvc.Service
{
    interface IUsuarioService
    {
        [Post("/api/v1/usuario/registrar")]
        Task<RegistrarUsuarioViewModelInput> Registrar(RegistrarUsuarioViewModelInput registrarUsuarioViewModelInput);

        [Post("/api/v1/usuario/logar")]
        Task<LoginViewModelOutput> Logar(LoginViewModelInput loginViewModelInput);

    }
}
