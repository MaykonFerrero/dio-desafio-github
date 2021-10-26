using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace course.web.mvc.Models.Usuario
{
    public class RegistrarUsuarioViewModelInput
    {
        [Required(ErrorMessage ="O login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

    }
}
