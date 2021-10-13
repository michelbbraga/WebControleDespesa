using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ControleDespesa5.Models;
using ControleDespesa5.Repositories;

namespace ControleDespesa5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //Armazena infromações na mermoria
            services.AddDistributedMemoryCache();
            // Trabalha com secessões
            services.AddSession();
            string conectionstring = Configuration.GetConnectionString("Default");
            services.AddDbContext<AplicationContext>(options => options.UseSqlServer(conectionstring));
            services.AddHttpContextAccessor();
            // Registra a injeção de dependencia
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IMovimentosDRRepository, MovimentosDRRepository>();
            services.AddTransient<IDespesaRepository, DespesaRepository>();
            services.AddTransient<IReceitaRepository, ReceitaRepository>();

            //services.AddTransient<IMovimentosDRRepository, MovimentosDRRepository>;

            //services.AddDbContext<AplicationContext>(options => options.UseSqlServer(conectionstring);
            //services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Ldespesa",
                    pattern: "{controller=FinanceiroController}/{action=Ldespesa}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Criar",
                    pattern: "{controller=FinanceiroController}/{action=Criar}/{id?}");
            });
            // gera o banco de dados caso não exista
            serviceProvider.GetService<IDataService>().InicializaDB();
        }
    }
}
