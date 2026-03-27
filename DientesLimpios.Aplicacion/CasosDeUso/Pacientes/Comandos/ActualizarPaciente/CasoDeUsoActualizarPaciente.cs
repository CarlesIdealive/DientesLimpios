using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.ActualizarPaciente;

public class CasoDeUsoActualizarPaciente : IRequestHandler<ComandoActualizarPaciente>
{
    private readonly IRepositorioPacientes repositorioPacientes;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CasoDeUsoActualizarPaciente(IRepositorioPacientes repositorioPacientes, IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorioPacientes = repositorioPacientes;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }


    public async Task Handle(ComandoActualizarPaciente request)
    {
        var paciente = await repositorioPacientes.ObtenerPorId(request.Id)
            ?? throw new ExcepcionNoEncontrado("Paciente no encontrado");

        // Validacion de Dominio para el nombre y el email
        paciente.ActualizarNombre(request.Nombre);
        paciente.ActualizarEmail(request.Email);
        try
        {
            await repositorioPacientes.Actualizar(paciente);
            await unidadDeTrabajo.Persistir();

        }
        catch (Exception ex)
        {
            await unidadDeTrabajo.Reversar();
            throw;

        }

    }





}
