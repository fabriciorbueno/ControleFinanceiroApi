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
            services.AddSingleton<IUsuarioService, UsuarioService>();
            services.AddSingleton<ICategoriaService, CategoriaService>();
            services.AddSingleton<IGastosService, GastosService>();

            //Repository
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSingleton(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddSingleton(typeof(ICategoriaRepository), typeof(CategoriaRepository));
            services.AddSingleton(typeof(IGastosRepository), typeof(GastosRepository));

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
