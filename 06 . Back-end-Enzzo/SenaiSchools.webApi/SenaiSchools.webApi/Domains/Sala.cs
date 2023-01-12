using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiSchools.webApi.Domains
{
    public partial class Sala
    {
        public Sala()
        {
            Alunos = new HashSet<Aluno>();
        }

        public int IdSala { get; set; }
        public string Titulo { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
