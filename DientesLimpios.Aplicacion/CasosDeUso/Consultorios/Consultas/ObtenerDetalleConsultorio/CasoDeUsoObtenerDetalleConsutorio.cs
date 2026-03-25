using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;

public class CasoDeUsoObtenerDetalleConsutorio 
    : IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>
{
    private readonly IRepositorioConsultorios _repositorioConsultorio;

    public CasoDeUsoObtenerDetalleConsutorio(IRepositorioConsultorios repositorioConsultorio)
    {
        _repositorioConsultorio = repositorioConsultorio;
    }


    public async Task<ConsultorioDetalleDTO> Handle(ConsultaObtenerDetalleConsultorio request)
    {
        var consultorio = await _repositorioConsultorio.ObtenerPorId(request.Id) 
            ?? throw new ExcepcionNoEncontrado("Consultorio no encontrado");

        //Los casos de uso no deben atender detalles de la capa de presentación,
        //por lo que se mapea en la propia clase 
        //var dto = new ConsultorioDetalleDTO
        //{
        //    Id = consultorio.Id,
        //    Nombre = consultorio.Nombre
        //};
        return consultorio.MapearADTO();
    }


}
