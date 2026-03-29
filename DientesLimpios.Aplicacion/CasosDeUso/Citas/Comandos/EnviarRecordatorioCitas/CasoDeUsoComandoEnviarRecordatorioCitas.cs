using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Contratos.Repositorios.Modelos;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Enums;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.EnviarRecordatorioCitas;

public class CasoDeUsoComandoEnviarRecordatorioCitas : IRequestHandler<ComandoEnviarRecordatorioCitas>
{
    private readonly IRepositorioCitas repositorioCitas;
    private readonly IServicioNotificaciones servicioNotificaciones;

    public CasoDeUsoComandoEnviarRecordatorioCitas(
        IRepositorioCitas repositorioCitas, 
        IServicioNotificaciones servicioNotificaciones)
    {
        this.repositorioCitas = repositorioCitas;
        this.servicioNotificaciones = servicioNotificaciones;
    }



    public async Task Handle(ComandoEnviarRecordatorioCitas request)
    {
        var mañana = DateTime.Now.AddDays(1);
        var fechaInicio = mañana;
        var fechaFin = mañana.AddDays(1);
        var filtro = new FiltroCitasDTO
        {
            FechaInicio = fechaInicio,
            FechaFin = fechaFin,
            EstadoCita = EstadoCita.Programada
        };

        var citas = await repositorioCitas.ObtenerFiltrado(filtro);
        foreach (var cita in citas)
        {
            var citaDTO = cita.ToDTO();
            await servicioNotificaciones.EnviarRecordatorioCita(citaDTO);
        }

    }

}
