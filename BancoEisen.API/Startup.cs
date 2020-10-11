using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BancoEisen.Controllers.Interfaces;
using BancoEisen.Controllers.Cadastros;
using BancoEisen.Controllers.Operacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using BancoEisen.API.Filters;
using BancoEisen.Data.Repositorios;
using BancoEisen.Data.Contextos;
using BancoEisen.Data.Repositorios.Interfaces;
using BancoEisen.API.Services.Interfaces;
using BancoEisen.Models.Cadastros;
using BancoEisen.API.Services;
using BancoEisen.Data.Services.Interfaces;
using BancoEisen.Data.Services;
using BancoEisen.Data.Models.Filtros;
using BancoEisen.Models.Operacoes;
using BancoEisen.Models.Abstracoes;
using BancoEisen.Data.Models.Filtros.Abstracoes;

namespace BancoEisen.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            { 
                options.EnableEndpointRouting = false;
                options.Filters.Add<BadRequestFilter>(1);
                options.Filters.Add<ErrorResponseFilter>(0);
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<BancoEisenContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BancoEisen"));
            });

            services.AddHttpContextAccessor();

            services.AddTransient<IContaRepositorio, ContaRepositorio>();
            services.AddTransient<IPessoaRepositorio, PessoaRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IOperacaoRepositorio, OperacaoRepositorio>();

            services.AddTransient<IContaController, ContaController>();
            services.AddTransient<IPessoaController, PessoaController>();
            services.AddTransient<IUsuarioController, UsuarioController>();
            services.AddTransient<IDepositoController, DepositoController>();
            services.AddTransient<ISaqueController, SaqueController>();
            services.AddTransient<ITransferenciaController, TransferenciaController>();
            
            services.AddTransient<IFiltragemService<Conta, ContaFiltro>, FiltragemService<Conta, ContaFiltro>>();
            services.AddTransient<IFiltragemService<Pessoa, PessoaFiltro>, FiltragemService<Pessoa, PessoaFiltro>>();
            services.AddTransient<IFiltragemService<Usuario, UsuarioFiltro>, FiltragemService<Usuario, UsuarioFiltro>>();
            services.AddTransient<IFiltragemService<Operacao, OperacaoFiltro>, FiltragemService<Operacao, OperacaoFiltro>>();
            services.AddTransient<IFiltragemService<Operacao, DepositoFiltro>, FiltragemService<Operacao, DepositoFiltro>>();
            services.AddTransient<IFiltragemService<Operacao, SaqueFiltro>, FiltragemService<Operacao, SaqueFiltro>>();
            services.AddTransient<IFiltragemService<Operacao, TransferenciaFiltro>, FiltragemService<Operacao, TransferenciaFiltro>>();
            
            services.AddTransient<IOrdenacaoService<Conta>, OrdenacaoService<Conta>>();
            services.AddTransient<IOrdenacaoService<Pessoa>, OrdenacaoService<Pessoa>>();
            services.AddTransient<IOrdenacaoService<Usuario>, OrdenacaoService<Usuario>>();
            services.AddTransient<IOrdenacaoService<Operacao>, OrdenacaoService<Operacao>>();

            services.AddTransient<IPaginacaoService, PaginacaoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
