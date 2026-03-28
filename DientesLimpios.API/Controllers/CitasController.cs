using DientesLimpios.API.DTOs.Citas;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitasController : ControllerBase
{
    private readonly IMediator mediator;

    public CitasController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CrearCita([FromBody] CrearCitaDTO crearCitaDTO)
    {
        var comando = new ComandoCrearCita
        {
            PacienteId = crearCitaDTO.PacienteId,
            DentistaId = crearCitaDTO.DentistaId,
            ConsultorioId = crearCitaDTO.ConsultorioId,
            FechaInicio = crearCitaDTO.FechaInicio,
            FechaFin = crearCitaDTO.FechaFin
        };
        var resultado = await mediator.Send(comando);
        return Ok();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CitaDetalleDTO>> Get(Guid id)
    {
        var consulta = new ConsultaObtenerDetalleCita { Id  = id };
        var resultado = await mediator.Send(consulta);
        return resultado;
    }













}
