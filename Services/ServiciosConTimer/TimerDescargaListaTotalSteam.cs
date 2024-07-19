using FlaggGaming.Entity;
using FlaggGaming.Services.CargaBaseDeDatos;
using static System.Formats.Asn1.AsnWriter;

namespace FlaggGaming.Services.ServiciosConTimer
{
    public class TimerDescargaListaTotalSteam : BackgroundService
    {
        private Timer? _timer;
        private readonly IServiceProvider _serviceProvider;

        public TimerDescargaListaTotalSteam(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; 
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DoWork(stoppingToken);
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
            return Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            if (_timer is not null)
            {
                await _timer.DisposeAsync();
                _timer = null;
            }
        }

        private async void DoWork(object? state)
        {
            using var scope = _serviceProvider.CreateScope();
            var scopedProcessingService = scope.ServiceProvider.GetRequiredService<CargaListaSteamEnBaseDeDatos>();
            await scopedProcessingService.insertListaSteamEnBD(state);
        }
    }
}

