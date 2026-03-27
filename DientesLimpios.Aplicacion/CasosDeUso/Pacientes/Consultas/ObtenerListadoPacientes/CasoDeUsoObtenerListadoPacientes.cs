using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Comunes;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;

public class CasoDeUsoObtenerListadoPacientes : IRequestHandler<ConsultaObtenerListadoPacientes, PaginadoDTO<PacienteListadoDTO>>
{
    private readonly IRepositorioPacientes repositorioPacientes;

    public CasoDeUsoObtenerListadoPacientes(IRepositorioPacientes repositorioPacientes)
    {
        this.repositorioPacientes = repositorioPacientes;
    }

    public async Task<PaginadoDTO<PacienteListadoDTO>> Handle(ConsultaObtenerListadoPacientes request)
    {
        var pacientes = await repositorioPacientes.ObtenerFiltrado(request);
        var totalPacientes = await repositorioPacientes.ObtenerCantidadTotalRegistros();
        var pacientesDtos = pacientes.Select(paciente => paciente.ADto()).ToList();
        var paginadoDTO = new PaginadoDTO<PacienteListadoDTO>
        {
            Elementos = pacientesDtos,
            Total = totalPacientes,
        };
        return paginadoDTO;
    }
}
