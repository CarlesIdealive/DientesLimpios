namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;

public static class MapeadorExtension
{

    public static PacienteListadoDTO ADto(this Dominio.Entidades.Paciente paciente)
    {
        var dto = new PacienteListadoDTO
        {
            Id = paciente.Id,
            Nombre = paciente.Nombre,
            Email = paciente.Email.Valor
        };
        return dto;
    }


}
