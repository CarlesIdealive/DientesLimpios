using DientesLimpios.API.DTOs.Consultorios;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.BorrarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultoriosController : ControllerBase
{
    private readonly IMediator mediator;

    public ConsultoriosController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CrearConsultorio(CrearConsultorioDTO crearConsultorioDTO)
    {
        var comando = new ComandoCrearConsultorio { Nombre = crearConsultorioDTO.Nombre };
        var resultado = await mediator.Send(comando);
        return Ok(resultado);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarConsultorio(Guid id, ActualizarConsultorioDTO actualizarConsultorioDTO)
    {
        var comando = new ComandoActualizarConsultorio { Nombre = actualizarConsultorioDTO.Nombre };
        await mediator.Send(comando);
        return NoContent();
    }


    [HttpGet]
    public async Task<ActionResult<List<ConsultorioDetalleDTO>>> ObtenerConsultorios()
    {
        // Aquí iría la lógica para obtener la lista de consultorios
        var resultado = await mediator.Send(new ConsultaObtenerDetalleConsultorio()); 
        return Ok(resultado);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ConsultorioDetalleDTO>> ObtenerConsultorioPorId(Guid id)
    {
        // Aquí iría la lógica para obtener un consultorio por su ID
        var resultado = await mediator.Send(new ConsultaObtenerDetalleConsultorio { Id = id }); 
        return Ok(resultado);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> BorrarConsultorio(Guid id)
    {
        var comando = new ComandoBorrarConsultorio { Id = id };
        await mediator.Send(comando);
        return NoContent();
    }



}
