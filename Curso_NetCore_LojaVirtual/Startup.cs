using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Curso_NetCore_LojaVirtual.Bibliotecas.Sessao;
using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Repositorios;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            services.AddHttpContextAccessor();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<INewsLettersRepositorio, NewsLettersRepositorio>();
            services.AddScoped<IColaboradoresRepositorio, ColaboradoresRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriasRepositorio>();



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

            services.AddScoped<SessoesSistema>();
            services.AddScoped<LoginCliente>();
            services.AddScoped<LoginColaboradores>();



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
            app.UseSession();
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
