namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;

public static class MapeadorExtensions
{

    public static CitaDetalleDTO ADto(this Dominio.Entidades.Cita cita)
    {
        return new CitaDetalleDTO
        {
            Id = cita.Id,
            Paciente = cita.Paciente?.Nombre ?? "Desconocido",
            Dentista = cita.Dentista?.Nombre ?? "Desconocido",
            Consultorio = cita.Consultorio?.Nombre ?? "Desconocido",
            Inicio = cita.IntervaloDeTiempo.Inicio,
            Fin = cita.IntervaloDeTiempo.Fin,
            EstadoCita = cita.EstadoCita.ToString()
        };
    }


}
