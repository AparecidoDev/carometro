using SenaiSchools.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiSchools.webApi.Interfaces
{
    interface ISalaRepository
    {
        /// <summary>
        /// Cadastra uma nova Sala
        /// </summary>
        /// <param name="NovaSala">Obejto NovoUsuario que será casdatrado</param>
        void CadastrarSala(Sala NovaSala);

        /// <summary>
        /// Atualiza uma Sala Existente 
        /// </summary>
        /// <param name="id">Id da Sala que será Atualizada</param>
        /// <param name="SalaAtualizada"></param>
        void AtualizarSala(int id, Sala SalaAtualizada);

        /// <summary>
        /// Lista todos as Salas
        /// </summary>
        /// <returns>Lista de Salas</returns>
        List<Sala> ListarSalas();

        /// <summary>
        /// Deleta uma Sala existente
        /// </summary>
        /// <param name="id">ID da Sala que será deletada</param>
        void DeletarSala(int id);
    }
}
