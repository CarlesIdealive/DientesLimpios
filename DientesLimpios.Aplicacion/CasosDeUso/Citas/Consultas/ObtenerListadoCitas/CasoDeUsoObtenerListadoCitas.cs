using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;

public class CasoDeUsoObtenerListadoCitas : IRequestHandler<ConsultaObtenerListadoCitas, List<CitaListadoDTO>>
{
    private readonly IRepositorioCitas repositorioCitas;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CasoDeUsoObtenerListadoCitas(IRepositorioCitas repositorioCitas, IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorioCitas = repositorioCitas;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }


    public async Task<List<CitaListadoDTO>> Handle(ConsultaObtenerListadoCitas request)
    {
        var citas = await repositorioCitas.ObtenerFiltrado(request);
        var citasDTO = citas.Select(cita => cita.ADto()).ToList();
        return citasDTO;
    }
}
