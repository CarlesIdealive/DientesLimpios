using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;
using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;

public class CasoDeUsoCrearCita : IRequestHandler<ComandoCrearCita, Guid>
{
    private readonly IRepositorioCitas repositorioCitas;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;
    private readonly IServicioNotificaciones notificaciones;

    public CasoDeUsoCrearCita(
        IRepositorioCitas repositorioCitas, 
        IUnidadDeTrabajo unidadDeTrabajo, 
        IServicioNotificaciones notificaciones)
    {
        this.repositorioCitas = repositorioCitas;
        this.unidadDeTrabajo = unidadDeTrabajo;
        this.notificaciones = notificaciones;
    }



    public async Task<Guid> Handle(ComandoCrearCita request)
    {
        var estaTomada = await repositorioCitas.ExisteCitaSolapada(request.DentistaId, request.FechaInicio, request.FechaFin);
        if (estaTomada)
            throw new ExcepcionDeValidacion("El dentista ya tiene una cita programada en ese horario.");
        Guid? id = null;
        try
        {
            var intervalo = new IntervaloDeTiempo(request.FechaInicio, request.FechaFin);
            var cita = new Cita(
                pacienteId: request.PacienteId,
                dentistaId: request.DentistaId,
                consultorioId: request.ConsultorioId,
                intervaloDeTiempo: intervalo);
            var respuesta = await repositorioCitas.Agregar(cita);
            id= respuesta.Id;
            await unidadDeTrabajo.Persistir();
        }
        catch (Exception ex)
        {
            await unidadDeTrabajo.Reversar();
            throw;
        }

        var citaDB = await repositorioCitas.ObtenerPorId(Id: id.Value);
        var notificacionDTO = citaDB!.ToDTO();
        await notificaciones.EnviarConfirmacionCita(notificacionDTO);
        return id.Value;
    }

}
