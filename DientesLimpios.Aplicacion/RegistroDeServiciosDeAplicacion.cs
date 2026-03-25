using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Aplicacion;

public static class RegistroDeServiciosDeAplicacion
{
    public static IServiceCollection AgregarServiciosDeAplicacion(this IServiceCollection servicios)
    {
        servicios.AddTransient<IMediator, MediadorSimple>();
        servicios.AddScoped<IRequestHandler<ComandoCrearConsultorio, Guid>, CasoDeUsoCrearConsultorio>();
        servicios.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>, CasoDeUsoObtenerDetalleConsutorio>();

        return servicios;
    }

}
