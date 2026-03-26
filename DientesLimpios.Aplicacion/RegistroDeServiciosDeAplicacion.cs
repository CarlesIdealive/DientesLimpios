using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace DientesLimpios.Aplicacion;

public static class RegistroDeServiciosDeAplicacion
{
    public static IServiceCollection AgregarServiciosDeAplicacion(this IServiceCollection servicios)
    {
        servicios.AddTransient<IMediator, MediadorSimple>();
        //Consultorios
        servicios.AddScoped<IRequestHandler<ComandoCrearConsultorio, Guid>, CasoDeUsoCrearConsultorio>();
        servicios.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>, CasoDeUsoObtenerDetalleConsutorio>();
        servicios.AddScoped<IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>, CasoDeUsoObtenerListadoConsultorios>();


        return servicios;
    }

}
