using ControleFinanceiro.Domain.Enums;
using ControleFinanceiro.Domain.Interfaces.Repositories;

namespace ControleFinanceiro.Domain.Shared
{
    public static class InjecaoDependenciaExtensions
    {
        public delegate IGenericRepository RepositoryResolverDI(TabelaEnum tabela);
    }
}
