using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ControleFinanceiroContext _context;
        private readonly DbSet<T> _entities;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseRepository(ControleFinanceiroContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;

            _entities = context.Set<T>();
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DbSet<T>> GetContext() => _entities;


        public async Task<T> BuscarAsync(int id)
        {
            return await _entities.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.Equals(id));
        }
        public async Task<bool> SalvarAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            _entities.Add(entity);

            await SalvarAsync();

            return true;
        }

        public async Task<EntityEntry<T>> SalvarAndReturnAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var resp = _entities.Add(entity);

            await SalvarAsync();

            return resp;
        }

        public async Task<bool> AtualizarAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            _context.Update(entity).State = EntityState.Modified;

            await SalvarAsync();

            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            T entity = await _entities.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.Equals(id));
            _entities.Remove(entity);

            await SalvarAsync();

            return true;
        }

        public async Task<IList<T>> BuscarTodosAsync()
        {
            return await _entities.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        private async Task SalvarAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _context.ChangeTracker.Clear();
            }
        }
    }

}
