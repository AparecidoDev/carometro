using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiSchools.webApi.ViewModels
{
    public class LoginViewModel
    {
        //Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o e-mail do Usuário!")]
        public string Email { get; set; }

        //Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a senha do Usuário")]

        public string Senha { get; set; }
    }
}
