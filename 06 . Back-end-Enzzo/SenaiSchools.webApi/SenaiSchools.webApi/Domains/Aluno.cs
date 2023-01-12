using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiSchools.webApi.Domains
{
    public partial class Aluno
    {
        public int IdAluno { get; set; }
        public int? IdSala { get; set; }
        public string NomeAluno { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string AnoLetivo { get; set; }
        public string Re { get; set; }
        public byte StatusAluno { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }

        public virtual Sala IdSalaNavigation { get; set; }
    }
}
