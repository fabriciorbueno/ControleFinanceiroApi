using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> SalvarAsync(T entity);

        Task<T> BuscarAsync(int id);

        Task<bool> AtualizarAsync(T entity);

        Task<bool> DeletarAsync(int id);

        /// <summary>
        /// Limitado a 50 para nao prejudicar a performance
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> BuscarTodosAsync();

        Task<DbSet<T>> GetContext();

        Task<EntityEntry<T>> SalvarAndReturnAsync(T entity);

    }
}
