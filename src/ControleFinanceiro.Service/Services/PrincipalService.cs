using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Dtos.Response;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class PrincipalService : IPrincipalService
    {
        private readonly IPrincipalRepository _repository;

        public PrincipalService(IPrincipalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PrincipalResponse>> BuscarTodosAsync()
        {
            return await _repository.BuscarTodosAsync();
        }

        public async Task<bool> InserirAsync(PrincipalRequest request)
        {
            request.Data = DateTime.Now.ToLocalTime();
            return await _repository.InserirAsync(request);
        }
    }
}
