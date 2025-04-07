using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Data.Repositories;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using ControleFinanceiro.Domain.Profiles;
using ControleFinanceiro.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace ControleFinanceiro.Service.Extensions
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseContext>();
            services.AddSingleton<ControleFinanceiroContext>();

            //services
            services.AddSingleton<ICategoriaService, CategoriaService>();
            services.AddSingleton<IDestinatarioService, DestinatarioService>();
            services.AddSingleton<IFormaPagamentoService, FormaPagamentoService>();
            services.AddSingleton<IGastosService, GastosService>();
            services.AddSingleton<IInstituicaoService, InstituicaoService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();

            //Repository
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSingleton(typeof(ICategoriaRepository), typeof(CategoriaRepository));
            services.AddSingleton(typeof(IDestinatarioRepository), typeof(DestinatarioRepository));
            services.AddSingleton(typeof(IFormaPagamentoRepository), typeof(FormaPagamentoRepository));
            services.AddSingleton(typeof(IGastosRepository), typeof(GastosRepository));
            services.AddSingleton(typeof(IInstituicaoRepository), typeof(InstituicaoRepository));
            services.AddSingleton(typeof(IUsuarioRepository), typeof(UsuarioRepository));

            //Mapper
            services.AddAutoMapper(typeof(ComecRegistroAdolescentesProfile).Assembly);

            services.AddHealthChecks();

            //Http Clients
            services.AddHttpClient("api-externa", c =>
            {
                c.BaseAddress = new Uri("https://localhost:5011/");
            });

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
