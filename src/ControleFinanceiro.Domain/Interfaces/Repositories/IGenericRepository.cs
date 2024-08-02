using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IGenericRepository
    {
        Task<IEnumerable<Entity>> BuscarTodosAsync();
        Task<bool> InserirAsync(RequestBase request);
    }
}
