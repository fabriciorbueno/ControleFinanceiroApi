using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Data.Repositories;
using ControleFinanceiro.Data.Rest;
using ControleFinanceiro.Domain.Enums;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Rest;
using ControleFinanceiro.Domain.Interfaces.Services;
using ControleFinanceiro.Domain.Profiles;
using ControleFinanceiro.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using static ControleFinanceiro.Domain.Shared.InjecaoDependenciaExtensions;


namespace ControleFinanceiro.Service.Extensions
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //context
            services.AddSingleton<DatabaseContext>();

            //services
            services.AddSingleton<IApiExternaService, ApiExternaService>();
            services.AddSingleton<IGenericService, GenericService>();
            services.AddSingleton<IPrincipalService, PrincipalService>();

            //Repository
            services.AddSingleton<BancoRepository, BancoRepository>();
            services.AddSingleton<CategoriaRepository, CategoriaRepository>();
            services.AddSingleton<DestinatarioRepository, DestinatarioRepository>();
            services.AddSingleton<LocalRepository, LocalRepository>();
            services.AddSingleton<PrioridadeRepository, PrioridadeRepository>();
            services.AddSingleton<SubCategoriaRepository, SubCategoriaRepository>();
            services.AddSingleton<TipoPagamentoRepository, TipoPagamentoRepository>();
            services.AddSingleton<IPrincipalRepository, PrincipalRepository>();

            //Rest
            services.AddSingleton(typeof(IBrasilAbertoAPI), typeof(BrasilAbertoAPI));

            //Mapper
            services.AddAutoMapper(typeof(GastosProfile).Assembly);

            services.AddHealthChecks();

            //Http Clients
            services.AddHttpClient("api-brasil-aberto", c =>
            {
                c.BaseAddress = new Uri("https://brasilaberto.com");
            });

            services.AddHttpContextAccessor();

            ConfigurarPost(services);

            return services;
        }

        private static void ConfigurarPost(this IServiceCollection services)
        {
            services.AddSingleton<RepositoryResolverDI>(serviceProvider => (tabelaEnum) =>
            {
                return tabelaEnum switch
                {
                    TabelaEnum.Banco => serviceProvider.GetService<BancoRepository>(),
                    TabelaEnum.Categoria => serviceProvider.GetService<CategoriaRepository>(),
                    TabelaEnum.Destinatario => serviceProvider.GetService<DestinatarioRepository>(),
                    TabelaEnum.Local => serviceProvider.GetService<LocalRepository>(),
                    TabelaEnum.Prioridade => serviceProvider.GetService<PrioridadeRepository>(),
                    TabelaEnum.SubCategoria => serviceProvider.GetService<SubCategoriaRepository>(),
                    TabelaEnum.TipoPagamento => serviceProvider.GetService<TipoPagamentoRepository>(),
                    _ => throw new NotSupportedException("Não foi localizado o repository."),
                };
            });
        }
    }
}
