namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerDetallePaciente;

public class PacienteDetalleDTO
{
    public required Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string Email { get; set; } = null!;

}
