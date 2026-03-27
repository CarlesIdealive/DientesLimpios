using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;

public class CasoDeUsoObtenerListadoPacientes : IRequestHandler<ConsultaObtenerListadoPacientes, List<PacienteListadoDTO>>
{
    private readonly IRepositorioPacientes repositorioPacientes;

    public CasoDeUsoObtenerListadoPacientes(IRepositorioPacientes repositorioPacientes)
    {
        this.repositorioPacientes = repositorioPacientes;
    }

    public async Task<List<PacienteListadoDTO>> Handle(ConsultaObtenerListadoPacientes request)
    {
        var pacientes = await repositorioPacientes.ObtenerTodos();
        return pacientes.Select(paciente => paciente.ADto()).ToList();

    }
}
