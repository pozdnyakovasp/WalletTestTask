using Domain.Rates;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Engine
{
    public class EngineService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public EngineService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var currencyRateEcbEuropaService = scope.ServiceProvider.GetService<ICurrencyRateEcbEuropaService>();
                    await currencyRateEcbEuropaService.Update();
                }
                catch
                {// todo log
                }

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
