using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.EnviarRecordatorioCitas;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.API.Jobs
{
    public class RecordatorioCitasJobs : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly TimeZoneInfo zon = TimeZoneInfo.FindSystemTimeZoneById("Europe/Madrid");

        public RecordatorioCitasJobs(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }



        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var ahora = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zon);
                    if (ahora.Hour == 9 && ahora.Minute == 0)
                    {
                        using var scope = scopeFactory.CreateScope();
                        var mediador = scope.ServiceProvider.GetRequiredService<IMediator>();
                        await mediador.Send(new ComandoEnviarRecordatorioCitas());
                    }
                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    //Logger.LogInformation("RecordatorioCitasJobs se ha cancelado.");
                    break;
                }


                //OPCION 2: CON TIMER
                //var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

                //while (await timer.WaitForNextTickAsync(stoppingToken))
                //{
                //    _logger.LogInformation("Procesando...");
                //    await _repo.ProcesarPedidosPendientesAsync(stoppingToken);
                //}


            }





        }

    }



    }
}
