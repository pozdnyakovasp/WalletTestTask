using Domain.Accounts;
using Domain.Infrastructure;
using Domain.Members;
using Domain.Rates;
using EFRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Wallet.Api
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
            services.AddSingleton(Configuration);
            services.AddControllers();

            services.AddDbContext<WalletDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("main"), b =>
            {
                b.MigrationsAssembly(typeof(WalletDbContext).Assembly.GetName().Name);
            }));

            services.AddHttpClient();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMemberAccountService, MemberAccountService>();

            services.AddTransient<ICurrencyRateService, CurrencyConverterService>();
            services.AddTransient<IMemberAccountService, MemberAccountService>();
            services.AddTransient<IMemberService, MemberService>();

            services.AddControllers();

            Migrate(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
                // todo
            }
        }
    }
}
