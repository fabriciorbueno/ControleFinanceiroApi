using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories
{
    public class GastosRepository : BaseRepository<Gastos>, IGastosRepository, IBaseRepository<Gastos>
    {
        public GastosRepository(
            ControleFinanceiroContext context,
            IHttpContextAccessor httpContextAccessor
            ) : base(context, httpContextAccessor)
        {
        }


        public async Task<IEnumerable<Gastos>> ObterTodosAsync()
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
        public async Task<IEnumerable<GastosResponse>> ObterPorUsuarioAsync(string cpf)
        {
            try
            {
                var result = await _context.Gastos.AsNoTracking()
                    .Where(x => x.UsuarioEntity.Cpf == cpf)
                    .Include(x => x.UsuarioEntity)
                    .Include(x => x.CategoriaEntity)
                    .Include(x => x.DestinatarioEntity)
                    .Include(x => x.FormaPagamentoEntity)
                    .Include(x => x.InstituicaoEntity)
                    .Select(x => new GastosResponse
                    {
                        Id = x.Id,
                        Valor = x.Valor,
                        DataHora = x.DataHora,
                        FormaPagamento = x.FormaPagamentoEntity.Descricao,
                        Instituicao = x.InstituicaoEntity.Descricao,
                        Destinatario = x.DestinatarioEntity.Descricao,
                        Categoria = x.CategoriaEntity.Descricao,
                        Observacoes = x.Observacoes,
                        Usuario = x.UsuarioEntity.Nome
                    })
                    .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AdicionarAsync(Gastos gastos)
        {
            try
            {
                var result = await SalvarAsync(gastos);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
