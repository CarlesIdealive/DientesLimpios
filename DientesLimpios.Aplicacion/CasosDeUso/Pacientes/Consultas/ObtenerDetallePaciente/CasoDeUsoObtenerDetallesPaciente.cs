using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Text;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerDetallePaciente;

public class CasoDeUsoObtenerDetallesPaciente
    : IRequestHandler<ConsultaObtenerDetallePaciente, PacienteDetalleDTO>
{
    private readonly IRepositorioPacientes repositorio;

    public CasoDeUsoObtenerDetallesPaciente(IRepositorioPacientes repositorio)
    {
        this.repositorio = repositorio;
    }


    public async Task<PacienteDetalleDTO> Handle(ConsultaObtenerDetallePaciente request)
    {
        var paciente = await repositorio.ObtenerPorId(request.Id)
            ?? throw new ExcepcionNoEncontrado("Paciente no encontrado");

        return paciente.MapearADTO()!;
    }
}
