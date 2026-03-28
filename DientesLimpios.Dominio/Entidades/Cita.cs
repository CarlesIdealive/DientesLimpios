using DientesLimpios.Dominio.Comunes;
using DientesLimpios.Dominio.Enums;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DientesLimpios.Dominio.Entidades;

public class Cita : EntidadAuditable
{
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid DentistaId { get; private set; }
    public Guid ConsultorioId { get; private set; }
    public EstadoCita EstadoCita { get; private set; }
    public IntervaloDeTiempo IntervaloDeTiempo { get; private set; }
    public Paciente? Paciente { get; private set; }
    public Dentista? Dentista { get; private set; }
    public Consultorio? Consultorio { get; private set; }



    private Cita()
    {
    }

    public Cita(Guid pacienteId, Guid dentistaId, Guid consultorioId, IntervaloDeTiempo intervaloDeTiempo)
    {
        AplicarReglasDeNegocioPaciente(pacienteId);
        AplicarReglasDeNegocioDentista(dentistaId);
        AplicarReglasDeNegocioConsultorio(consultorioId);

        if (intervaloDeTiempo.Inicio < DateTime.UtcNow)
        {
            throw new ArgumentException("La fecha de inicio no puede ser en el pasado.");
        }

        Id = Guid.CreateVersion7();
        PacienteId = pacienteId;
        DentistaId = dentistaId;
        ConsultorioId = consultorioId;
        IntervaloDeTiempo = intervaloDeTiempo;
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


    //Metodo para actualizar el Nombre del paciente
    public void ActualizarConsultorio(Guid nuevoConsultorio)
    {
        AplicarReglasDeNegocioConsultorio(nuevoConsultorio);
        ConsultorioId = nuevoConsultorio;
    }
    public void ActualizarPaciente(Guid nuevoPaciente)
    {
        AplicarReglasDeNegocioPaciente(nuevoPaciente);
        PacienteId = nuevoPaciente;
    }

    public void ActualizarDentista(Guid nuevoDentista)
    {
        AplicarReglasDeNegocioDentista(nuevoDentista);
        DentistaId = nuevoDentista;
    }












    private void AplicarReglasDeNegocioPaciente(Guid idPaciente)
    {
        if (idPaciente == Guid.Empty)
        {
            throw new ExcepcionReglaDeNegocio("El Id del paciente no puede estar vacío.");
        }
    }

    private void AplicarReglasDeNegocioDentista(Guid idDentista)
    {
        if (idDentista == Guid.Empty)
        {
            throw new ExcepcionReglaDeNegocio("El Id del dentista no puede estar vacío.");
        }
    }

    private void AplicarReglasDeNegocioConsultorio(Guid idConsultorio)
    {
        if (idConsultorio == Guid.Empty)
        {
            throw new ExcepcionReglaDeNegocio("El Id del consultorio no puede estar vacío.");
        }
    }


}