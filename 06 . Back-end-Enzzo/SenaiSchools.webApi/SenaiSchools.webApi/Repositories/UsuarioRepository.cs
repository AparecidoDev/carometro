using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiSchools.webApi.Contexts;
using SenaiSchools.webApi.Domains;
using SenaiSchools.webApi.Interfaces;

namespace SenaiSchools.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        SenaiContext ctx = new SenaiContext();

        public void AtualizarUsuario(int id, Usuario UsuarioAtualizado)
        {
            // Busca um usuário através do id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica se o nome do usuário foi informado
            if (UsuarioAtualizado.Nome != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Nome = UsuarioAtualizado.Nome;
            }

            // Verifica se a matricula do usuário foi informada
            if (UsuarioAtualizado.Matricula != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Matricula = UsuarioAtualizado.Matricula;
            }

            // Verifica se o e-mail do usuário foi informado
            if (UsuarioAtualizado.Email != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Email = UsuarioAtualizado.Email;
            }

            // Verifica se a senha do usuário foi informado
            if (UsuarioAtualizado.Senha != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            // Atualiza o tipo de usuário que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public List<Usuario> BuscarPorId(int id)
        {
            // Retorna o primeiro usuário encontrado para o ID informado, sem exibir sua senha
             Usuario user = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);


            return ctx.Usuarios
                 .Select(u => new Usuario()
                 {
                     IdUsuario = u.IdUsuario,
                     Email = u.Email,
                     Matricula = u.Matricula,
                     TipoUsuario = u.TipoUsuario,
                     StatusUsuario = u.StatusUsuario,
                     Nome = u.Nome
                 })

                 .ToList();
        }

        public void CadastrarUsuario(Usuario NovoUsuario)
        {
            // Adiciona este novoUsuario
            ctx.Usuarios.Add(NovoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            // Remove o tipo de usuário que foi buscado
            Usuario userBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(userBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
