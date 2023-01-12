using SenaiSchools.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiSchools.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        //Definicao dos Métodos
        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="NovoUsuario">Obejto NovoUsuario que será casdatrado</param>
        void CadastrarUsuario(Usuario NovoUsuario);

        /// <summary>
        /// Atualiza um Usuario Existente 
        /// </summary>
        /// <param name="id">Id do Usuário que será Atualizado</param>
        /// <param name="UsuarioAtualizado"></param>
        void AtualizarUsuario(int id, Usuario UsuarioAtualizado);


        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        List<Usuario> BuscarPorId(int id);

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void DeletarUsuario(int id);

        /// <summary>
        /// Valida o Usuário
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>objeto do usuario que foi buscado</returns>
        Usuario Login(string email, string senha);
    }
}
