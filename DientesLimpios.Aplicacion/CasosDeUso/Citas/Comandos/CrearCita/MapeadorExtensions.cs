using DientesLimpios.Aplicacion.Contratos.Notificaciones;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;

public static class MapeadorExtensions
{
    public static ConfirmacionCitaDTO ToDTO(this Dominio.Entidades.Cita cita)
    {
        return new ConfirmacionCitaDTO
        {
            Id = cita.Id,
            Paciente = cita.Paciente!.Nombre,
            Paciente_Email = cita.Paciente.Email.Valor,
            Dentista = cita.Dentista!.Nombre ,
            Consultorio = cita.Consultorio!.Nombre,
            Fecha = cita.IntervaloDeTiempo.Inicio
        };
    }

}
