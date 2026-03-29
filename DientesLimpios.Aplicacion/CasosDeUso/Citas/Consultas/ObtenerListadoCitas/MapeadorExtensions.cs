namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;

public static class MapeadorExtensions
{

    public static CitaListadoDTO ADto(this Dominio.Entidades.Cita cita)
    {
        return new CitaListadoDTO
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
