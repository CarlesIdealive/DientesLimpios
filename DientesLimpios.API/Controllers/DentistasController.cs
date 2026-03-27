using DientesLimpios.API.DTOs.Dentistas;
using DientesLimpios.Aplicacion.CasosDeUso.Dentista.Comandos.CrearDentista;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.ObjetosDeValor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistasController : ControllerBase
    {
        private readonly IMediator mediator;

        public DentistasController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CrearDentista(CrearDentistaDTO crearDentistaDTO)
        {
            var comando = new ComandoCrearDentista { Nombre = crearDentistaDTO.Nombre, Email = crearDentistaDTO.Email };
            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }




    }
}
