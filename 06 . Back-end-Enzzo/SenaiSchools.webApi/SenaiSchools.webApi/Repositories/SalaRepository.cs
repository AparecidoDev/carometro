using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiSchools.webApi.Domains;
using SenaiSchools.webApi.Contexts;
using SenaiSchools.webApi.Interfaces;

namespace SenaiSchools.webApi.Repositories
{
    public class SalaRepository : ISalaRepository
    {

        SenaiContext ctx = new SenaiContext();

        public void AtualizarSala(int id, Sala SalaAtualizada)
        {
            Sala salaBuscada = ctx.Salas.Find(id);

            if(salaBuscada.Titulo != null && salaBuscada.Numero != null)
            {
                salaBuscada.Titulo = SalaAtualizada.Titulo;
                salaBuscada.Numero = SalaAtualizada.Numero;
            }

            ctx.Salas.Update(salaBuscada);
            ctx.SaveChanges();
        }

        public void CadastrarSala(Sala NovaSala)
        {
            ctx.Salas.Add(NovaSala);

            ctx.SaveChanges();
        }

        public void DeletarSala(int id)
        {
            Sala salaBuscada = ctx.Salas.Find(id);

            if(salaBuscada != null)
            {
                ctx.Salas.Remove(salaBuscada);
            }

            ctx.SaveChanges();
        }

        public List<Sala> ListarSalas()
        {
            return ctx.Salas.ToList();
        }
    }
}
