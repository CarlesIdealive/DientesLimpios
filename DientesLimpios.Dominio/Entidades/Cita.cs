using DientesLimpios.Dominio.Enums;
using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.Entidades;

public class Cita
{
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid DentistaId { get; private set; }
    public Guid ConsultorioId { get; private set; }
    public EstadoCita EstadoCita { get; private set; }
    public DateTime FechaInicio { get; private set; }
    public DateTime FechaFin { get; private set; }
    public Paciente? Paciente { get; private set; }
    public Dentista? Dentista { get; private set; }
    public Consultorio? Consultorio { get; private set; }


    public Cita(Guid pacienteId, Guid dentistaId, Guid consultorioId, DateTime fechaInicio, DateTime fechaFin)
    {
        if (fechaFin < fechaInicio)
        {
            throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio.");
        }
        if (fechaInicio < DateTime.Now)
        {
            throw new ArgumentException("La fecha de inicio no puede ser en el pasado.");
        }

        Id = Guid.CreateVersion7();
        PacienteId = pacienteId;
        DentistaId = dentistaId;
        ConsultorioId = consultorioId;
        FechaFin = fechaFin;
        FechaInicio = fechaInicio;
        EstadoCita = EstadoCita.Programada;
    }


    public void Cancelar()
    {
        if (EstadoCita != EstadoCita.Programada)
        {
            throw new ExcepcionReglaDeNegocio("Solo se pueden cancelar citas programadas");
        }
        EstadoCita = EstadoCita.Cancelada;
    }

    public void Completar()
    {
        if (EstadoCita != EstadoCita.Programada)
        {
            throw new ExcepcionReglaDeNegocio("Solo se pueden completar citas programadas");
        }
        EstadoCita = EstadoCita.Completada;
    }


}