using AutoMapper;
using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Dtos.Response;
using ControleFinanceiro.Domain.Enums;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ControleFinanceiro.Domain.Shared.InjecaoDependenciaExtensions;

namespace ControleFinanceiro.Service.Services
{
    public class GenericService : IGenericService
    {
        private readonly RepositoryResolverDI _repository;
        private readonly IMapper _mapper;

        public GenericService(
            RepositoryResolverDI repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IGenericRepository> EscolherRepository(TabelaEnum tabela)
        {
            return _repository(tabela);
        }

        public async Task<IEnumerable<ResponseBase>> BuscarTodosAsync(TabelaEnum tabela)
        {
            var repositoryEscolhido = await EscolherRepository(tabela);

            var response = await repositoryEscolhido.BuscarTodosAsync();

            return _mapper.Map<IEnumerable<ResponseBase>>(response);
        }

        public async Task<bool> InserirAsync(TabelaEnum tabela, RequestBase categoriaRequest)
        {
            var repositoryEscolhido = await EscolherRepository(tabela);

            var response = await repositoryEscolhido.InserirAsync(categoriaRequest);
            return response;
        }
    }
}
