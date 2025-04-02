using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository, IBaseRepository<Usuario>
    {
        public UsuarioRepository(
            ControleFinanceiroContext context,
            IHttpContextAccessor httpContextAccessor
            ) : base(context, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
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

        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            try
            {
                var result = await SalvarAndReturnAsync(usuario);
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> ObterPorCpfAsync(string cpf)
        {
            try
            {
                var result = await _context.Usuario.FirstOrDefaultAsync(x => x.Cpf == cpf);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
