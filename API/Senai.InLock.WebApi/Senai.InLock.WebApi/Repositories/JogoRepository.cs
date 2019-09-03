using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {

        private string StringConexao = "Data Source=localhost;Initial Catalog=T_InLock;User Id=sa;Pwd=132;";


        InLockContext ctx = new InLockContext();

        public object SqlDataReader { get; private set; }

        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                
                return ctx.Jogos.Include(x => x.Estudio).ToList();
            }
        }

        public Jogos BuscarPorId(int id)
        {
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

        // Extra

        public List<Jogos> ListaTop5()
        {
            return ctx.Jogos.FromSql("Select Top(5) * from Jogos order by Valor desc").ToList();     
        }

        public List<Jogos> ListaPorData()
        {
            return ctx.Jogos.FromSql("Select * from Jogos order by DataLancamento desc").ToList();
        }

        public Jogos BuscarPorNome(string Nome)
        {
            return ctx.Jogos.FirstOrDefault(x => x.NomeJogo == Nome);
            //return ctx.Jogos.FromSql("select * from Jogos WHERE NomeJogo = @jogo.Nome").ToList();
        }

        
    }
}
