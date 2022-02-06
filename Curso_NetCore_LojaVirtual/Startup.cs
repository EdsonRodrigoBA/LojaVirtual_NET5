using Curso_NetCore_LojaVirtual.Bibliotecas.AutoMapper;
using Curso_NetCore_LojaVirtual.Bibliotecas.CarrinhoCompras;
using Curso_NetCore_LojaVirtual.Bibliotecas.Cookie;
using Curso_NetCore_LojaVirtual.Bibliotecas.Email;
using Curso_NetCore_LojaVirtual.Bibliotecas.Gerenciador.Frete;
using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Curso_NetCore_LojaVirtual.Bibliotecas.Middlware;
using Curso_NetCore_LojaVirtual.Bibliotecas.Sessao;
using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Repositorios;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ws_Correios;

namespace Curso_NetCore_LojaVirtual
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /**
             * Envio de Email
             */
            services.AddScoped<SmtpClient>(options =>
            {
                SmtpClient smtpClient = new SmtpClient(Configuration.GetValue<String>("Email:serverSMTP"), Configuration.GetValue<int>("Email:port"));
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Configuration.GetValue<String>("Email:usuario"), Configuration.GetValue<String>("Email:senha"));
                smtpClient.EnableSsl = true;

                return smtpClient;
            });


            //instancia web services correios

            services.AddScoped<CalcPrecoPrazoWSSoap>(options =>
            {

                var servico = new CalcPrecoPrazoWSSoapClient(CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);

                return servico;

            });

            /*
             Adicionando Automapper
             */
            services.AddAutoMapper(oonfig => oonfig.AddProfile<MappingProfile>());
            services.AddScoped<GerenciarEnvioEmails>();


            services.AddHttpContextAccessor();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<INewsLettersRepositorio, NewsLettersRepositorio>();
            services.AddScoped<IColaboradoresRepositorio, ColaboradoresRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriasRepositorio>();
            services.AddScoped<IprodutosRepositorio, ProdutoRepositorio>();
            services.AddScoped<IImagensRepositorio, ImagensRepositorio>();



            services.AddControllersWithViews();
            string dbConnection = Configuration.GetConnectionString("CursoLojaVirtual");
            services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(dbConnection));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });
            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                //options.MinimumSameSitePolicy = SameSiteMode.None;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;


            });

            services.AddScoped<SessoesSistema>();
            services.AddScoped<CookieSistema>();
            services.AddScoped<CookieCarrinhoCompras>();
            services.AddScoped<CookieCarrinhoPrazoFrete>();


            services.AddScoped<LoginCliente>();
            services.AddScoped<LoginColaboradores>();
            services.AddScoped<ws_Correios_CalcularFrete>();
            services.AddScoped<CalcularPacote>();



            services.AddMvc(options =>
            {
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor {0} não é válido para {1}.");
                options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "Não foi fornecido um valor para o campo {0}.");
                options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Campo obrigatório.");
                options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "É necessário que o body na requisição não esteja vazio.");
                options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => "O valor {0} não é válido.");
                options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor fornecido é inválido.");
                options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser um número.");
                options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => "O valor fornecido é inválido para {0}.");
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => "O valor fornecido é inválido para {0}.");
                options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo {0} deve ser um número.");
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "O campo deve ser preenchido.");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseSession();
            app.UseMiddleware<ValidateAntiFogeryTokenMiddlware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
