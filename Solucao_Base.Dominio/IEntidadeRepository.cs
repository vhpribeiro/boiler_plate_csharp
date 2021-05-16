using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solucao_Base.Dominio
{
    public interface IEntidadeBaseRepository<T> where T : Entidade
    {
        Task InserirUma(T entidade);
        Task AtualizarUma(T entidade);
        Task DeletarUma(T entidade);
        Task<IList<T>> SelecionarTodasPor(Expression<Func<T, bool>> filtro = null);
        Task<T> SelecionarUmaPor(Expression<Func<T, bool>> filtro = null);
    }
}
