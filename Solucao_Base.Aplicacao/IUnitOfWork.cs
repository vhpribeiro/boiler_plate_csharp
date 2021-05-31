using System.Threading.Tasks;

namespace Solucao_Base.Aplicacao
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
