using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.web.mvc.Models.Usuario
{
    public class LoginViewModelOutput
    {
        
        public string Token { get; set; }
        
        public DetalhesUsuario Usuario { get; set; }

    }

    public class DetalhesUsuario
    {
        public int Codigo { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

    }
}
