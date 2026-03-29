using DientesLimpios.Dominio.Enums;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios.Modelos;

public class FiltroCitasDTO
{
    public int Pagina { get; set; }
    public int RegistrosPorPagina { get; set; } = 10;
    public Guid? PacienteId { get; set; }
    public Guid? ConsultorioId { get; set; }
    public Guid? DentistaId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public EstadoCita? EstadoCita { get; set; }


}
