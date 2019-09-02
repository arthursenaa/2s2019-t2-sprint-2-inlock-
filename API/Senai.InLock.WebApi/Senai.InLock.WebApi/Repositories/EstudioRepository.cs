using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {              
                return ctx.Estudios.ToList();
            }
        }

        public Estudios BuscarPorId(int id)
        {      
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }

        public void Cadastrar (Estudios estudio)
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
    }
}
