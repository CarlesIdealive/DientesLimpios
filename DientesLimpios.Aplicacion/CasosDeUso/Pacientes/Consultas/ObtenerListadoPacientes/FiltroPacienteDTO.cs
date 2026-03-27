namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;

public class FiltroPacienteDTO
{
    public int Pagina { get; set; }
    public int RegistrosPorPagina { get; set; } = 10;

}
