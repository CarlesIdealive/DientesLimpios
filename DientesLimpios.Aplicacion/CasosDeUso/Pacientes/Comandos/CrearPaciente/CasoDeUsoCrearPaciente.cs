using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente;

public class CasoDeUsoCrearPaciente : IRequestHandler<ComandoCrearPaciente, Guid>
{

    private readonly IRepositorioPacientes _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoCrearPaciente(
        IRepositorioPacientes repositorio, 
        IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
    }



    public async Task<Guid> Handle(ComandoCrearPaciente request)
    {
        var paciente = new Paciente(request.Nombre, request.Email);
        try
        {
            await _repositorio.Agregar(paciente);
            await _unidadDeTrabajo.Persistir();
            return paciente.Id;
        }
        catch (Exception ex)
        {
            await _unidadDeTrabajo.Reversar();
            // Manejo de excepciones
            throw;
        }

    }

}
