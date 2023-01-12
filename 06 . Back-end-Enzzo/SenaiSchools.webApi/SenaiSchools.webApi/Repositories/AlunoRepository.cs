using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiSchools.webApi.Contexts;
using SenaiSchools.webApi.Domains;
using SenaiSchools.webApi.Interfaces;

namespace SenaiSchools.webApi.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        SenaiContext ctx = new SenaiContext();

        public void AtualizarAluno(int id, Aluno AlunoAtualizado)
        {
            Aluno alunoBuscado = ctx.Alunos.Find(id);

            if (alunoBuscado.NomeAluno != null && alunoBuscado.Email != null && alunoBuscado.Endereco != null && alunoBuscado.AnoLetivo != null && alunoBuscado.IdSala != 0 && alunoBuscado.Telefone != null && alunoBuscado.Re != null)
            {
                alunoBuscado.NomeAluno = AlunoAtualizado.NomeAluno;
                alunoBuscado.Email = AlunoAtualizado.Email;
                alunoBuscado.Endereco = AlunoAtualizado.Endereco;
                alunoBuscado.AnoLetivo = AlunoAtualizado.AnoLetivo;
                alunoBuscado.IdSala = AlunoAtualizado.IdSala;
                alunoBuscado.Telefone = AlunoAtualizado.Telefone;
                alunoBuscado.Re = AlunoAtualizado.Re;
                alunoBuscado.Foto = AlunoAtualizado.Foto;
                alunoBuscado.Descricao = AlunoAtualizado.Descricao;
            }

            ctx.Alunos.Update(alunoBuscado);

            ctx.SaveChanges();
           
        }

        public void CadastrarAluno(Aluno NovoAluno)
        {
            ctx.Alunos.Add(NovoAluno);

            ctx.SaveChanges();
        }

        public void DeletarAluno(int id)
        {
            Aluno alunoBuscado = ctx.Alunos.Find(id);

            if(alunoBuscado != null)
            {
                ctx.Alunos.Remove(alunoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Aluno> ListarAlunos()
        {
            return ctx.Alunos.ToList();
        }
    }
}
