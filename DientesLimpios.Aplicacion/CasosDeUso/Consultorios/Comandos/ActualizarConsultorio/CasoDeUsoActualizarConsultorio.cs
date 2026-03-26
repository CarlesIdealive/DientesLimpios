using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;

public class CasoDeUsoActualizarConsultorio : IRequestHandler<ComandoActualizarConsultorio>
{
    private readonly IRepositorioConsultorios _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoActualizarConsultorio(IRepositorioConsultorios repositorioConsultorios, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorioConsultorios;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoActualizarConsultorio request)
    {
        var consultorio = await _repositorio.ObtenerPorId(request.Id) 
            ?? throw new ExcepcionNoEncontrado($"No se ha encontrado el consultorio {request.Nombre}");
        //Validacion de Dominio para el nombre del consultorio
        consultorio.ActualizarNombre(request.Nombre);
        try
        {
            await _repositorio.Actualizar(consultorio);
            await _unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }
    }


}
