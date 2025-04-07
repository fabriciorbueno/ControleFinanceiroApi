using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories
{
    public class DestinatarioRepository : BaseRepository<Destinatario>, IDestinatarioRepository, IBaseRepository<Destinatario>
    {
        public DestinatarioRepository(
            ControleFinanceiroContext context,
            IHttpContextAccessor httpContextAccessor
            ) : base(context, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<Destinatario>> ObterTodosAsync()
        {
            try
            {
                var result = await BuscarTodosAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
