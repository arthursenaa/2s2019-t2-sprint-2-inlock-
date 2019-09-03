using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.Jogos).ToList();
            }
        }

        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }

        public void Cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioProcurado = ctx.Estudios.FirstOrDefault(x => x.EstudioId == estudio.EstudioId);

                EstudioProcurado.NomeEstudio = estudio.NomeEstudio;
                ctx.Estudios.Update(EstudioProcurado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios estudio = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorNome(string Nome)
        {
            Estudios estudio = ctx.Estudios.Include(X => X.Jogos).FirstOrDefault(x => x.NomeEstudio == Nome);
            //ctx.Estudios.Include(X => X.Jogos);

            return estudio;
        }

        //public Estudios BuscarPorPais(string pais)
        //{
         //   Estudios estudios = ctx.Estudios.FirstOrDefault(x => x.PaisOrigem == pais);
            //ctx.Estudios.ToList(estudios);
            //return ctx.Estudios.FromSql("Select NomeEstudio from Estudios where PaisOrigem = ");
            //return ctx.Estudios.Find(pais);
        //    return estudio;
        //}
    }
}
