using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.EnviarRecordatorioCitas;

public static class MapeadorExtensions
{

    public static RecordatorioCitaDTO ToDTO(this Cita cita)
    {
        return new RecordatorioCitaDTO
        {
            Id = cita.Id,
            Paciente = cita.Paciente!.Nombre,
            Paciente_Email = cita.Paciente.Email.Valor,
            Dentista = cita.Dentista!.Nombre,
            Consultorio = cita.Consultorio!.Nombre,
            Fecha = cita.IntervaloDeTiempo.Inicio
        };
    }
}
