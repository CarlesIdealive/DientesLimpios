using DientesLimpios.API.DTOs.Pacientes;
using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente;
using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly IMediator mediator;

    public PacientesController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CrearPaciente([FromBody] CrearPacienteDTO crearPacienteDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var comando = new ComandoCrearPaciente{
            Nombre = crearPacienteDTO.Nombre, 
            Email = crearPacienteDTO.Email 
        };
        var resultado = await mediator.Send(comando);
        return Ok(resultado);
    }


    [HttpGet]
    public async Task<ActionResult<List<PacienteListadoDTO>>> ObtenerPacientes()
    {
        // Aquí podrías implementar la lógica para obtener la lista de pacientes
        var consulta = new ConsultaObtenerListadoPacientes();
        var resultado = await mediator.Send(consulta);
        return Ok(resultado);
    }



}
