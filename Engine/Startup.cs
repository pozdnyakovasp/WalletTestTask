using Application.Engine;
using Domain.Infrastructure;
using Domain.Rates;
using EFRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Protocols.EcbEuropa;
using Protocols.EcbEuropa.Services;
using System;

namespace Engine
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddControllers();

            services.AddDbContext<WalletDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("main"), b =>
            {
                b.MigrationsAssembly(typeof(WalletDbContext).Assembly.GetName().Name);
            }));

            services.AddHttpClient();
            services.AddTransient<IEcbMessageConverter, EcbMessageConverter>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEcbEuropaProtocol, EcbEuropaProtocol>();
            services.AddTransient<ICurrencyRateEcbEuropaService, CurrencyRateEcbEuropaService>();
            services.AddHostedService<EngineService>();

            Migrate(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        private void Migrate(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            try
            {
                var context = provider.GetRequiredService<WalletDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                // todo log
            }
        }
    }
}
