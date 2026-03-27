namespace DientesLimpios.Aplicacion.CasosDeUso.Dentista.Consultas;

public class FiltroDentistaDTO
{
    public int Pagina { get; set; }
    public int RegistrosPorPagina { get; set; } = 10;
    public string? Nombre { get; set; }
    public string? Email { get; set; }
}
