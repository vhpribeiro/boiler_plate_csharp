using Microsoft.EntityFrameworkCore;
using Solucao_Base.Dominio;
using Solucao_Base.Infra._Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solucao_Base.Infra.Repositorios
{
    public class EntidadeBaseRepository<T> : IEntidadeBaseRepository<T> where T : Entidade
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<T> Entidade;

        public EntidadeBaseRepository(DatabaseContext context)
        {
            Context = context;
            Entidade = Context.Set<T>();
        }

        public async virtual Task InserirUma(T entidade)
        {
            await Entidade.AddAsync(entidade);
            await Context.SaveChangesAsync();
        }

        public async virtual Task AtualizarUma(T entidade)
        {
            Entidade.Update(entidade);
            await Context.SaveChangesAsync();
        }

        public async virtual Task DeletarUma(T entidade)
        {
            await AtualizarUma(entidade);
        }

        public async virtual Task<IList<T>> SelecionarTodasPor(Expression<Func<T, bool>> filtro = null)
        {
            if (filtro == null)
                return await Entidade.ToListAsync();

            return await Entidade.Where(filtro).ToListAsync();
        }

        public async virtual Task<T> SelecionarUmaPor(Expression<Func<T, bool>> filtro = null)
        {
            return await Entidade.SingleOrDefaultAsync(filtro);
        }
    }
}
