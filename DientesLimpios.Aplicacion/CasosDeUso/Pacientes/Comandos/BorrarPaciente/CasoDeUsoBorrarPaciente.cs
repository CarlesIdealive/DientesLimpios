using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Text;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.BorrarPaciente;

public class CasoDeUsoBorrarPaciente : IRequestHandler<ComandoBorrarPaciente>
{
    private readonly IRepositorioPacientes repositorioPacientes;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CasoDeUsoBorrarPaciente(IRepositorioPacientes repositorioPacientes,
        IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorioPacientes = repositorioPacientes;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }


    public async Task Handle(ComandoBorrarPaciente request)
    {
        var paciente = await repositorioPacientes.ObtenerPorId(request.Id) 
            ?? throw new ExcepcionNoEncontrado("Paciente no encontrado");

        try
        {
            await repositorioPacientes.Borrar(paciente);
            await unidadDeTrabajo.Persistir();

        }
        catch (Exception)
        {
            await unidadDeTrabajo.Reversar();
            throw;
        }
    }



}
