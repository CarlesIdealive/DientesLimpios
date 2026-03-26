using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.BorrarConsultorio;

public class CasoDeUsoBorrarConsultorio : IRequestHandler<ComandoBorrarConsultorio>
{
    private readonly IRepositorioConsultorios _repositorioConsultorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoBorrarConsultorio(IRepositorioConsultorios repositorioConsultorios, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorioConsultorio = repositorioConsultorios;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoBorrarConsultorio request)
    {
        var consultorio = await _repositorioConsultorio.ObtenerPorId(request.Id);
        if (consultorio == null)
        {
            throw new ExcepcionNoEncontrado("Consultorio no encontrado.");
        }

        try
        {
            await _repositorioConsultorio.Borrar(consultorio);
            await _unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }
    }


}
