namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;

public static class MapeadorExtensions
{
    public static ConsultorioDetalleDTO? MapearADTO(this Dominio.Entidades.Consultorio consultorio)
    {
        if (consultorio == null) return null;
        return new ConsultorioDetalleDTO
        {
            Id = consultorio.Id,
            Nombre = consultorio.Nombre
        };
    }

}
