using SenaiSchools.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiSchools.webApi.Interfaces
{
    interface IAlunoRepository
    {
        /// <summary>
        /// Cadastra um novo Aluno
        /// </summary>
        /// <param name="NovoAluno">Obejto NovoAluno que será casdatrado</param>
        void CadastrarAluno(Aluno NovoAluno);

        /// <summary>
        /// Atualiza um Aluno Existente 
        /// </summary>
        /// <param name="id">Id do Aluno que será Atualizado</param>
        /// <param name="AlunoAtualizado"></param>
        void AtualizarAluno(int id, Aluno AlunoAtualizado);

        /// <summary>
        /// Lista todos os Alunos
        /// </summary>
        /// <returns>Lista de Alunos</returns>
        List<Aluno> ListarAlunos();

        /// <summary>
        /// Deleta um Aluno existente
        /// </summary>
        /// <param name="id">ID do Aluno que será deletado</param>
        void DeletarAluno(int id);

    }
}
