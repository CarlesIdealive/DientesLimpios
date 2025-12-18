using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;

public class CasoDeUsoCrearConsultorio
{
    private readonly IRepositorioConsultorios _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;
    public CasoDeUsoCrearConsultorio(IRepositorioConsultorios repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
    }



    public async Task<Guid> Handle(ComandoCrearConsultorio comando)
    {
        // Lógica para crear un consultorio - Orquestación del dominio
        // Por ejemplo, validar datos, guardar en base de datos, etc.
        // Simulación de creación y retorno de un ID único para el consultorio creado
        var consultorio = new Consultorio(comando.Nombre);
        try
        {
            var respuesta = await _repositorio.Agregar(consultorio);
            await _unidadDeTrabajo.Persistir();
            return respuesta.Id;

        }
        catch (Exception ex)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }

    }
}
