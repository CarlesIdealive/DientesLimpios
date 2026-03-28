using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;

public class CasoDeUsoObtenerDetalleCita : IRequestHandler<ConsultaObtenerDetalleCita, CitaDetalleDTO>
{
    private readonly IRepositorioCitas repositorioCitas;

    public CasoDeUsoObtenerDetalleCita(IRepositorioCitas repositorioCitas)
    {
        this.repositorioCitas = repositorioCitas;
    }

    public async Task<CitaDetalleDTO> Handle(ConsultaObtenerDetalleCita request)
    {

        var cita = await repositorioCitas.ObtenerPorId(request.Id)
            ?? throw new ExcepcionNoEncontrado("Cita no encontrada");
        return cita.ADto();
    }


}
