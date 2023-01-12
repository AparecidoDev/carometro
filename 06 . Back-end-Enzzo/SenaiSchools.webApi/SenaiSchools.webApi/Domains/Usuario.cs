using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiSchools.webApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte TipoUsuario { get; set; }
        public byte StatusUsuario { get; set; }
    }
}
