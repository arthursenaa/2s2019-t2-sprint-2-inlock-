using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        InLockContext ctx = new InLockContext();
         
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                
                return ctx.Jogos.Include(x => x.Estudio).ToList();
            }
        }

        public Jogos BuscarPorId(int id)
        {
            //using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
            }
        }

        public void Cadastrar(Jogos jogos)
        {
            ctx.Jogos.Add(jogos);
            ctx.SaveChanges();
        }

        public void Atualizar(Jogos jogos)
        {
            Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogos.JogoId);
            JogoBuscado.NomeJogo = jogos.NomeJogo;
            ctx.Jogos.Update(JogoBuscado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogos jogos = ctx.Jogos.Find(id);
            ctx.Jogos.Remove(jogos);
            ctx.SaveChanges();
        }
    }
}
